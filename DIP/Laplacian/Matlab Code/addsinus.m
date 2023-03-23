function addsinus()
f = imread('G:\Fig0458(a)(blurry_moon).tif');
g = sinus(f);
%spatial domain
figure;
subplot(2,2,1);imshow(f,[]);
subplot(2,2,2);imshow(g,[]);
subplot(2,2,3);imshow(double(f)+real(g),[]);

%frequency domain
F = fft2(f);
G = fft2(g);
figure;
subplot(2,2,1);imshow(fftshift(log(F+1)),[]);
subplot(2,2,2);imshow(fftshift(log(G+1)),[]);
subplot(2,2,3);imshow(fftshift(log(F+G+1)),[]);
subplot(2,2,4);imshow(ifft2(F+G),[]);
end
function output=sinus(f)
    [m,n] = size(f);
    N = zeros(m,n);
    for x=1:m
        A = rand*200;
        u = rand*500;
        v = rand*500;
        for y=1:n    
            N(x,y) = A*sin(2*pi*u*x + 2*pi*v*y);
        end
    end
    output = N;
end