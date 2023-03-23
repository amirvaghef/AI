function face_detection()

 

originalImage = imread('1.png'); 
gry_img=rgb2gray(originalImage);
%---start estimate face region-----
R=originalImage(:,:,1);
G=originalImage(:,:,2);
B=originalImage(:,:,3);
[m,n]=size(B);
s=zeros(m,n);
Y=0.257*R + 0.504*G+ 0.098*B+ 16;
Cb=0.148*R- 0.291*G+ 0.439*B+ 128;
Cr=0.439 *R -0.368*G -0.071*B +128;
for x=1:m
    for p=1:n
       if(( 144<Cr(x,p))&&(Cr(x,p)<185) && (150<Cb(x,p))&& (Cb(x,p)<185))
           s(x,p)=originalImage(x,p);
       end
    end
end
% morphological closing, returning the
% closed image
se = strel('disk',2);
imclos=imclose(s,se);

binaryImage = im2bw(imclos, 0.8);       % Threshold to binary 
binaryImage = imfill(binaryImage, 'holes'); 

% Label each blob so can do calc on it
labeledImage = bwlabel(binaryImage, 8);    


blobMeasurements = regionprops(labeledImage, 'all');   % Get all the blob properties. 
numberOfBlobs = size(blobMeasurements, 1); 
% bwboundaries returns a cell array, where each cell 
% contains the row/column coordinates for an object in the image. 
% Plot the borders of all the coins on the original 
% grayscale image using the coordinates returned by bwboundaries. 

imagesc(originalImage); title('Outlines'); 
hold on; 
boundaries = bwboundaries(binaryImage); 
for k = 1 : numberOfBlobs 
    thisBlobsPixels = blobMeasurements(k).PixelIdxList;
    meanGL = mean(double(originalImage(thisBlobsPixels)));
    stdGL = std(double(originalImage(thisBlobsPixels)));
     blobArea = blobMeasurements(k).Area; 
       blobCentroid = blobMeasurements(k).Centroid; % Get centroid.
       
        
     if ((blobArea>390) && (blobArea<1900))&&((stdGL>22)&&(meanGL>135))
          
          thisBoundary = boundaries{k}; 
      % plot(thisBoundary(:,2), thisBoundary(:,1), 'g', 'LineWidth', 1); 
       hold on
      plot( blobCentroid(1,1), blobCentroid(1,2),'--bs',...
                'MarkerFaceColor','g',...
                'MarkerSize',5)
     end
end
hold off; 
%fprintf(1,'Blob #      Mean Intensity  Area     Perimeter  Centroid\n'); 
%for k = 1 : numberOfBlobs           % Loop through all blobs. 
        % Find the mean of each blob.  (R2008a has a better way where you can pass the original image 
        % directly into regionprops.  The way below works for all versions including earlier versions.) 
%    thisBlobsPixels = blobMeasurements(k).PixelIdxList;  % Get list of pixels in current blob. 
%    meanGL = mean(originalImage(thisBlobsPixels));             % Find mean intensity (in original image!) 
 %       blobArea = blobMeasurements(k).Area;            % Get area. 
 %       blobPerimeter = blobMeasurements(k).Perimeter;          % Get perimeter. 
 %       blobCentroid = blobMeasurements(k).Centroid;            % Get centroid. 
 %       center{k}=blobCentroid;
 %   fprintf(1,'#%d %18.1f %11.1f %8.1f %8.1f %8.1f\n', k, meanGL, blobArea, blobPerimeter, blobCentroid); 
%end 

%msgbox('Finished running BlobsDemo.m.  Check out the figure window and the command window for the results.'); 

end