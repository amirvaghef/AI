﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ShapeContext.Properties;

using LiniarAlgebra;
using System.Collections;


namespace ShapeContext
{
    #region Delegates
    /// <summary>
    /// A delegate supporting selection of points from a full set of points.
    /// </summary>
    /// <param name="i_FullSet">A set of points to select from</param>
    /// <returns>An array of selected points</returns>
    public delegate Point[] SelectSamplesDelegate(Point[] i_FullSet, int i_numOfPoints);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="i_PointsToAlign"></param>
    public delegate void AlignmentDelegate(ref Point[] i_PointsToAlign);
    #endregion
    /// <Name>          A Shape Context algorithm based matching.   </Name>
    /// <Version>           0.1a Pre release                        </Version>
    /// <FileName>          ShapeContextMatching.cs                 </FileName>
    /// <ClassName>         ShapeContextMatching                    </ClassName>
    /// <OriginalAlgorithmBy>**************************************************
    ///     <Name>          Shaul Gaidelman                         </Name>
    ///     <Email>         shaulg@...                              </Email>
    /// </OriginalAlgorithmBy>
    /// <RefactoredAndModified>
    ///     <Name>          Yanir Tafkev                            </Name>
    ///     <Email>         yanirta@gmail.com                       </Email>
    /// </RefactoredAndModified>***********************************************
    /// <Guidance>
    ///     <Name>                                                  </Name>
    ///     <Email>                                                 </Email>
    /// </Guidance>
    /// <Institution>
    /// </Institution>
    /// <Date>              Sep. - 2009                             </Date>
    /// <License>
    ///The following code was created by Yanir Taflev followed by Shaul Gaidelman's implementation. 
    ///It is released for use under the AFL v3.0 (Academic Free License):
    ///This program is open source.  For license terms, see the AFL v3.0 terms at http://www.opensource.org/licenses/afl-3.0.php.
    ///Copyright (c) 2008 - 2009, Y. Taflev by S. Gaidelman's implementation.
    ///All rights reserved.
    ///
    ///     Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
    ///
    ///         * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
    ///         * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
    ///
    ///     THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
    ///     "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
    ///     LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
    ///     A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
    ///     CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
    ///     EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
    ///     PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
    ///     PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
    ///     LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
    ///     NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
    ///     SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
    /// </License>
    /// <summary>
    /// Shape context is an algorithm matching two monocolored (dark colored) , described by outlines, drawings.
    /// The algorithm gets two sets of points, sampled from the drawings (First from the original,Second from the target). 
    /// Note that the length of the two sets must be identical, otherwise exception is thrown.
    /// The output of the algorithms is array of indexes that indicates for each point from the original set,
    /// what is the corresponding point at the target set.
    /// 
    /// The algorithm provide a good base to identify differences between two shapes, based on the distances betweend
    /// matching points. The more runs of the algorithm, the better indication for the matching.
    /// Some matchings may be false, identify a length for a treshold that suits best for your purposes.
    /// </summary>
    /// <References>
    /// http://en.wikipedia.org/wiki/Shape_context
    /// Matching with Shape Contexts - S. Belongie and J. Malik (2000).
    /// Shape Matching and Object Recognition Using Shape Contexts - S. Belongie, J. Malik, and J. Puzicha (April 2002).
    /// Thin Plate Splines matlab implementation by Fitzgerald J Archibald.
    /// </References>
    /// <SpecialThanks></SpecialThanks> 
    public class ShapeContextMatching
    {
        private static readonly int[]   sr_NoMapping = null;
        private static readonly int     sr_Xaxis = 0;
        private static readonly int     sr_Yaxis = 1;

        private Point[] m_Shape1Samples;
        private Point[] m_Shape2Samples;

        private Point[] m_Shape1Points;     // the original model points
        private Point[] m_Shape2Points;     // the imitation model points
        private Size    m_SurfaceSize;

        DoubleMatrix    m_costMatrix;

        private DoubleMatrix[] m_Shape1Histogram;
        private DoubleMatrix[] m_Shape2Histogram;

        private int[] m_Matches;

        public ShapeContextMatching(Point[] i_Shape1Points, Point[] i_Shape2Points,Size i_SurfaceSize, SelectSamplesDelegate samplesSelectionLogic)
	    {
            NumOfThetaBins   = int.Parse(Resources.k_DefaultThetaBins);
            NumOfBins        = int.Parse(Resources.k_DefaultNumOfBins);
            NumOfIterations  = int.Parse(Resources.k_DefaultNumOfIterations);
            DistanceTreshold = double.Parse(Resources.k_DefaultDistanceTreshold);
            m_Matches        = null;
            
            m_Shape1Points  = i_Shape1Points;
            m_Shape2Points  = i_Shape2Points;
            m_SurfaceSize   = i_SurfaceSize;
            SelectionLogic  = samplesSelectionLogic;
	    }

        /// <summary>
        /// Prepare Shape context matching on the samples that preveously given in the C'tor.
        /// </summary>
        /// The result will be stored under ResultPoints property.
        /// This property will return full set of points as they needed to be displayed.
        public void Calculate()
        {       
            int iN = NumOfIterations;

            Point[] fullSourceSet = m_Shape1Points;
            Point[] fullTargetSet = m_Shape2Points;

            double euMinDistance = double.MaxValue;
            
            m_Shape1Samples = SelectionLogic(fullSourceSet, -1);

            OnBetweenIterations(ref fullTargetSet);

            //Selecting fresh target points set                
            m_Shape2Samples = SelectionLogic(fullTargetSet, NumOfIterations * m_Shape1Samples.Length);
            //Matching using core Shape context algorithms
            DetermineMatches(m_Shape1Samples, m_Shape2Samples);

            //Converting and sequencing the samples according to the matchings we've found
            Pair<DoubleMatrix, DoubleMatrix> SourceTargetMap = buildMappingByIndex(m_Shape1Samples, m_Shape2Samples, m_Matches);
            //There are some harshly wrong matches, will try eliminate them using a treshold.
            //Without this stage, TPS can ruin our data in a way that it wont be usefull anymore.
            if (DistanceTreshold > 0)
            {
                enforceEuDistance(ref SourceTargetMap, DistanceTreshold);
            }

            //Preparing TPS algorithm
            TPS tpsWarpping = new TPS(m_SurfaceSize, SourceTargetMap.Element2);
            //Calculating transformation
            tpsWarpping.Calculate(SourceTargetMap.Element1);
            //Interpolating whole target
            tpsWarpping.Interpolate(ref fullTargetSet);

            #region Preveous Method
            /*
            do
            {
                OnBetweenIterations(ref fullTargetSet);

                //Selecting fresh target points set                
                m_Shape2Samples = SelectionLogic(fullTargetSet, -1);
                //Matching using core Shape context algorithms
                DetermineMatches(m_Shape1Samples, m_Shape2Samples);
                //Converting and sequencing the samples according to the matchings we've found
                Pair<DoubleMatrix, DoubleMatrix> SourceTargetMap = buildMappingByIndex(m_Shape1Samples, m_Shape2Samples, m_Matches);
                //There are some harshly wrong matches, will try eliminate them using a treshold.
                //Without this stage, TPS can ruin our data in a way that it wont be usefull anymore.
                if (DistanceTreshold > 0)
                {
                    enforceEuDistance(ref SourceTargetMap, DistanceTreshold);
                }

                //Preparing TPS algorithm
                TPS tpsWarpping = new TPS(m_SurfaceSize, SourceTargetMap.Element2);
                //Calculating transformation
                tpsWarpping.Calculate(SourceTargetMap.Element1);
                //Transforming first of all , our target samples, this will indicate for quality of the improvment.
                tpsWarpping.Interpolate(ref m_Shape2Samples);
                //Calculating the distance between our source samples and the interpolated target samples.
                double euNewDistance = Utils.EuclidDistance(m_Shape1Samples, m_Shape2Samples);
                //If there was improvement in a meanings of total euclid distance, will transform(inerpolate) whole target set.
                if (euMinDistance > euNewDistance)
                {
                    euMinDistance = euNewDistance;
                    tpsWarpping.Interpolate(ref fullTargetSet);
                }
            } while (iN-- > 0);
            */
            #endregion
            m_Shape2Points = fullTargetSet;

        }

        private void OnBetweenIterations(ref Point[] fullTargetSet)
        {
            if (OnIterationEnd != null)
            {
                OnIterationEnd(ref fullTargetSet);
            }
        }

        public int[] DetermineMatches(Point[] i_SourceSamples, Point[] i_TargetSamples)
        {
            double shape1DistanceAvg, shape2DistanceAvg;

            //Calculate histogram - Next version can be in two threads
            m_Shape1Histogram = calcHistograms(i_SourceSamples, out shape1DistanceAvg);
            m_Shape2Histogram = calcHistograms(i_TargetSamples, out shape2DistanceAvg);

            m_costMatrix = calculateCostMatrix();

            //m_Matches = HungarianAlgorithm.Run(m_costMatrix);
            Dictionary<int,Pair<int,double>> matchingDetails;
            m_Matches = determineBestDistance(m_costMatrix, out matchingDetails); //Alternative method to find best matches

            return m_Matches;
        }



        #region Private Section

        private int[] determineBestDistance(DoubleMatrix m_costMatrix,out Dictionary<int, Pair<int, double>> o_MatchingData)
        {
            int[] retSuiteIndexes = new int[m_costMatrix.RowsCount];

            o_MatchingData = new Dictionary<int, Pair<int, double>>();
            Queue<int> waitingToMatch = new Queue<int>();

            //Initializing queue
            for (int row = 0; row < m_costMatrix.RowsCount; ++row)
            {
                waitingToMatch.Enqueue(row);
            }

            while (waitingToMatch.Count != 0)
            {
                int currSourceIndex = waitingToMatch.Dequeue();

                int lowIndex = -1;
                double lowestValue = double.MaxValue;
                

                for (int col = 0; col < m_costMatrix.ColumnsCount; ++col)
                {
                    if (lowestValue > m_costMatrix[currSourceIndex, col])
                    {
                        bool isBetterMatch = false;

                        if ((o_MatchingData.ContainsKey(col)) &&
                            (o_MatchingData[col].Element2 > m_costMatrix[currSourceIndex, col]))
                        {

                            waitingToMatch.Enqueue(o_MatchingData[col].Element1);
                            o_MatchingData.Remove(col);
                            isBetterMatch = true;

                        }

                        if ((isBetterMatch) || (!o_MatchingData.ContainsKey(col)))
                        {
                            o_MatchingData.Remove(lowIndex);
                            lowestValue = m_costMatrix[currSourceIndex, col];
                            lowIndex = col;

                            Pair<int, double> matchData;
                            matchData.Element1 = currSourceIndex;
                            matchData.Element2 = lowestValue;
                            o_MatchingData.Add(lowIndex, matchData);                            
                        }

                    }
                }

                retSuiteIndexes[currSourceIndex] = lowIndex;
            }

            return retSuiteIndexes;
        }

        private void reduceNullDistance(ref Pair<DoubleMatrix, DoubleMatrix> io_PairedSets)
        {
            int ZeroDistanceCount = 0;
            DoubleMatrix sourcePoints = io_PairedSets.Element1;
            DoubleMatrix targetPoints = io_PairedSets.Element2;

            for (int row = 0; row < sourcePoints.RowsCount; ++row)
            {
                if (sourcePoints[row, sr_Xaxis] == targetPoints[row, sr_Xaxis] &&
                    sourcePoints[row, sr_Yaxis] == targetPoints[row, sr_Yaxis])
                {
                    ZeroDistanceCount++;
                }
            }

            int newRowIndex = 0;
            DoubleMatrix newSource = new DoubleMatrix(sourcePoints.RowsCount - ZeroDistanceCount, sourcePoints.ColumnsCount);
            DoubleMatrix newTarget = new DoubleMatrix(targetPoints.RowsCount - ZeroDistanceCount, targetPoints.ColumnsCount);

            for (int row = 0; row < sourcePoints.RowsCount; ++row)
            {
                if (sourcePoints[row, sr_Xaxis] != targetPoints[row, sr_Xaxis] ||
                    sourcePoints[row, sr_Yaxis] != targetPoints[row, sr_Yaxis])
                {
                    newSource[newRowIndex, sr_Xaxis] = sourcePoints[row, sr_Xaxis];
                    newSource[newRowIndex, sr_Yaxis] = sourcePoints[row, sr_Yaxis];
                    newTarget[newRowIndex, sr_Xaxis] = targetPoints[row, sr_Xaxis];
                    newTarget[newRowIndex, sr_Yaxis] = targetPoints[row, sr_Yaxis];
                    ++newRowIndex;
                }
            }

            io_PairedSets.Element1 = newSource;
            io_PairedSets.Element2 = newTarget;
        }

        private void enforceDistance(ref Pair<DoubleMatrix, DoubleMatrix> io_PairedSets, double i_TresholdFromSurfSize)
        {
            if (i_TresholdFromSurfSize < 0 || i_TresholdFromSurfSize > 100)
            {
                throw new ShapeContextAlgoException("i_TresholdFromSurfSize parameter is not in percents format");
            }

            double[] treshold = new double[2];

            treshold[sr_Xaxis] = (double)m_SurfaceSize.Width / 100.0 * i_TresholdFromSurfSize;
            treshold[sr_Yaxis] = (double)m_SurfaceSize.Height / 100.0 * i_TresholdFromSurfSize;

            DoubleMatrix sourcePoints = io_PairedSets.Element1;
            DoubleMatrix targetPoints = io_PairedSets.Element2;

            Func<int, int, double, double> cellLogic = (row, col, val) =>
            {
                if (Math.Abs(val - sourcePoints[row, col]) > treshold[col])
                {
                    return sourcePoints[row, col];
                }
                return val;
            };

            targetPoints.Iterate(cellLogic);
        }

        private void enforceEuDistance(ref Pair<DoubleMatrix, DoubleMatrix> io_PairedSets, double i_TresholdFromSurfSize)
        {
            if (i_TresholdFromSurfSize < 0 || i_TresholdFromSurfSize > 100)
            {
                throw new ShapeContextAlgoException("i_TresholdFromSurfSize parameter is not in percents format");
            }

            DoubleMatrix sourcePoints = io_PairedSets.Element1;
            DoubleMatrix targetPoints = io_PairedSets.Element2;
            //A percantage of a surface's diagonal length.
            double treshold = Utils.EuclidDistance(new Point(0, 0), new Point(m_SurfaceSize)) / 100 * i_TresholdFromSurfSize;

            for (int row = 0; row < sourcePoints.RowsCount; ++row)
            {
                double distance = Utils.EuclidDistance(sourcePoints[row, sr_Xaxis], sourcePoints[row, sr_Yaxis], targetPoints[row, sr_Xaxis], targetPoints[row, sr_Yaxis]);

                if (distance > treshold)
                {
                    targetPoints[row, sr_Xaxis] = sourcePoints[row, sr_Xaxis];
                    targetPoints[row, sr_Yaxis] = sourcePoints[row, sr_Yaxis];
                }
            }
        }

        private Pair<DoubleMatrix, DoubleMatrix> buildMappingByIndex(Point[] i_sourceMapping, Point[] i_targetMapping, int[] i_matches)
        {
            Pair<DoubleMatrix, DoubleMatrix> retMapping = new Pair<DoubleMatrix, DoubleMatrix>();
            retMapping.Element1 = LiniarAlgebraFunctions.PointArrayToMatrix(i_sourceMapping, sr_NoMapping);
            retMapping.Element2 = LiniarAlgebraFunctions.PointArrayToMatrix(i_targetMapping, i_matches);
            return retMapping;
        }

        private void calcHistograms(out double o_Shape1DistanceAvg, out double o_Shape2DistanceAvg)
        {
            // original model histogram
            m_Shape1Histogram = Histogram.CreateHistogram(m_Shape1Samples, NumOfThetaBins, NumOfBins, out o_Shape1DistanceAvg);

            // imitation model histogram
            m_Shape2Histogram = Histogram.CreateHistogram(m_Shape2Samples, NumOfThetaBins, NumOfBins, out o_Shape2DistanceAvg);
        }

        private DoubleMatrix[] calcHistograms(Point[] i_ShapePoints, out double o_ShapecalcHistograms)
        {
            return Histogram.CreateHistogram(i_ShapePoints, NumOfThetaBins, NumOfBins, out o_ShapecalcHistograms);
        }

        /// <summary>
        /// each entry in histogram points to NxM matrix
        /// were N is number of radius(dist rings) and M is the number of bins
        /// </summary>
        /// <returns></returns>
        private DoubleMatrix calculateCostMatrix()
        {
            if (m_Shape1Histogram.Length > m_Shape2Histogram.Length)
            {
                throw new ShapeContextAlgoException("The source histograms number doesn't cover target's number");
            }

            int N1 = m_Shape1Histogram.Length;
            int N2 = m_Shape2Histogram.Length;

            DoubleMatrix histogram1, histogram2;
            DoubleMatrix costMatrix = new DoubleMatrix(N1,N2);

            for (int i = 0; i < N1; ++i)
            { // go over all points histograms

                histogram1 = m_Shape1Histogram[i];
                for (int j = 0; j < N2; ++j)
                {
                    histogram2 = m_Shape2Histogram[j];

                    if (histogram1.CellCount != histogram2.CellCount)
                    {
                        throw new ShapeContextAlgoException("Histogram doesn't have same dimension");
                    }

                    costMatrix[i, j] = calcTwoHistogramsCost(histogram1, histogram2);
                }
            }

            return costMatrix;
        }

        private double calcTwoHistogramsCost(DoubleMatrix i_Histogram1, DoubleMatrix i_Histogram2)
        {
            double val1, val2, sum = 0, histogram1Sum, histogram2Sum;
            int rowLen = i_Histogram1.RowsCount, colLen = i_Histogram1.ColumnsCount;

            histogram1Sum = i_Histogram1.Sum();
            histogram2Sum = i_Histogram2.Sum();

            for (int i = 0; i < rowLen; ++i)
            {
                for (int j = 0; j < colLen; ++j)
                {
                    // normelized value
                    val1 = i_Histogram1[i, j] / histogram1Sum;
                    val2 = i_Histogram2[i, j] / histogram2Sum;

                    if ((val1 + val2) != 0)
                    {
                        sum += Math.Pow(val1 - val2, 2) / (val1 + val2);
                    }
                }
            }
            return sum / 2;

            //for (int i = 0; i < rowLen; ++i)
            //{
            //    for (int j = 0; j < colLen; ++j)
            //    {
            //        // normelized value
            //        val1 = i_Histogram1[i, j];
            //        val2 = i_Histogram2[i, j];

            //        if ((val1 + val2) != 0)
            //        {
            //            sum += Math.Pow(val1 - val2, 2);
            //        }
            //    }
            //}
            //return Math.Sqrt(sum);

        }

        #endregion

        #region Properties

        public int NumOfThetaBins { get; set; }
        public int NumOfBins { get; set; }

        /// <summary>
        /// If optimization/Relaxing method is used, 
        /// NumOfIterations sets the number of times to run that optimization/Relaxing method.
        /// </summary>
        public int NumOfIterations { get; set; }

        /// <summary>
        /// The maximum distance that the matches will be still valid
        /// </summary>
        public double DistanceTreshold { get; set; }

        /// <summary>
        /// The full points set of the target after matching and relaxation.
        /// </summary>
        public Point[] ResultPoints
        {
            get
            { 
                return m_Shape2Points; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point[] SourcePoints
        {
            get
            {
                return m_Shape1Points;
            }
        }
        /// <summary>
        /// A method used to randomize selected amount of sample points.
        /// </summary>
        public SelectSamplesDelegate SelectionLogic;

        public AlignmentDelegate OnIterationEnd;

        public Point[] LastSourceSamples
        {
            get
            {
                return m_Shape1Samples;
            }
        }
        public Point[] LastTargetSamples
        {
            get
            {
                return Utils.ReindexArray(m_Shape2Samples, m_Matches);
            }
        }
        #endregion

    }
}
