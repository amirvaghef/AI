function correlate()
    originalImage = imread('subjects.JPG');
    originalImage = rgb2gray(originalImage);
    templateImage = imread('tmple.jpg');
    templateImage = rgb2gray(templateImage);
    corrImage = normxcorr2(templateImage ,originalImage);
    corrImage = im2bw(corrImage, 0.5);
    figure;
    imshow(corrImage);
    
    labeledRegion = bwlabel(corrImage, 8);
    regionProperties = regionprops(labeledRegion, 'all'); 
    regionNO = size(regionProperties, 1);
    
    figure;
    imshow(originalImage);
    hold on; 
    for k = 1 : regionNO
        centroid = regionProperties(k).Centroid;
        plot( centroid(1,1)-30, centroid(1,2)-50,'--bs','MarkerFaceColor','g','MarkerSize',5);
    end
hold off;
end