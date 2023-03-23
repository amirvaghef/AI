function Laplacian()
img = imread('g:\img372.gif');%'G:\Fig0458(a)(blurry_moon).tif');

lapsp = fspecial('laplacian',0);
%imf = imfilter(img, lapsp);

%img2 = im2double(img);
imf2 = imfilter(im2double(img), lapsp);

img3 = double(img) - imf2;

figure;
%subplot(2,2,1);imshow(img,[]);
%subplot(2,2,2);imshow(imf,[]);
%subplot(2,2,3);imshow(imf2,[]);
%subplot(2,2,4);imshow(img3,[]);
subplot(1,2,1);imshow(img,[]);title('Original Image');
subplot(1,2,2);imshow(img3,[]);title('Result Image');


%[k1,k2] = size(lapsp);
lappad =Huv(img);
%lappad = zeros(size(img));
%lappad([end+1-floor(k1/2):end,1:ceil(k1/2)], ...
%    [end+1-floor(k2/2):end,1:ceil(k2/2)]) = lapsp;
imgF =fft2(img);

%lapspF = lappad;
%imfF = ifft2(lappad.*imgF); %lapspF.*imgF;

imf2F = lappad.*imgF;

img3F = im2double(img) - imf2F; %imf2F;

figure;
%subplot(2,2,1);imshow(ifft2(imgF),[]);
%subplot(2,2,2);imshow(imfF,[]);
%subplot(2,2,3);imshow(ifft2(imf2F),[]);
%subplot(2,2,4);imshow(ifft2(img3F),[]);
subplot(1,2,1);imshow(ifft2(imgF),[]);title('Original Image');
subplot(1,2,2);imshow(ifft2(img3F),[]);title('Result Image');
end

function output=Huv(img)
[x,y]=size(img);
for u=1:x
    for v=1:y
        H(u,v)=-(power(u-x/2,2)+power(v-y/2,2));
    end
end
output=H;
end