function GaussianLaplacian()
img = imread('Zebra.jpg');
img = img(:,:,1);
%[m,n] = size(img);
flt = fspecial('gaussian',5,5);
imgStage{1} = img;
figure('Name','Guassian Pyramid','NumberTitle','off');
subplot(2,4,1);
imshow(imgStage{1}); 
for i=1:7
    imgStage{i} = imfilter(imgStage{i}, flt); 
    imgStage{i+1}=imgStage{i}(1:2:end,1:2:end);
    subplot(2,4,i+1);
    imshow(imgStage{i+1}); 
end

figure('Name','Laplacian Pyramid','NumberTitle','off');
subplot(2,4,8);
imshow(imgStage{8});
imgStageLap{8} = imgStage{8};
for i=7:-1:1
    %imgStage{i} = imfilter(imgStage{i}, flt); 
    %imgStage{i-1}=imgStage{i}(1:2:end,1:2:end);
    [m,n]=size(imgStage{i});
    %[m2,n2]=size(imgStage{i}); 
    %imgStageLap{i}() = zeros(m,n);    
    imgTemp=zeros(m,n);
    for j=1:m/2
       % imgStageLap{i}(2*j-1:2*j,:) = imgStage{i+1}(j,:);
       imgTemp(2*j-1,1:n/2)=imgStage{i+1}(j,1:n/2);
       imgTemp(2*j,1:n/2)=imgStage{i+1}(j,1:n/2);
    end
    imgTemp2 = zeros(m,n);
    for k=1:n/2
        imgTemp2(:,2*k-1) = imgTemp(:,k);
        imgTemp2(:,2*k) = imgTemp(:,k);
    end
    im1 = imgStage{i};
    im2 = im1 - uint8(imgTemp2);
    imgStageLap{i} = im2;
    subplot(2,4,i);
    imshow(imgStageLap{i},[]); 
end

figure('Name','Gaussian Pyramid From Laplacian Pyramid','NumberTitle','off');
subplot(2,4,8);
imshow(imgStage{8});
imgStagenew{8} = imgStage{8};
for i=7:-1:1
    [m,n]=size(imgStage{i});
    %% C
    imgTemp=zeros(m,n);
    for j=1:m/2
       imgTemp(2*j-1,1:n/2)=imgStage{i+1}(j,1:n/2);
       imgTemp(2*j,1:n/2)=imgStage{i+1}(j,1:n/2);
    end
    imgTemp2 = zeros(m,n);
    for k=1:n/2
        imgTemp2(:,2*k-1) = imgTemp(:,k);
        imgTemp2(:,2*k) = imgTemp(:,k);
    end
    %%
    im1 = imgStageLap{i};
    im2 = im1 + uint8(imgTemp2);
    imgStagenew{i} = im2;
    subplot(2,4,i);
    imshow(imgStagenew{i}); 
end

end