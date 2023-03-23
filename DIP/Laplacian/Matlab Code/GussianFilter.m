function GussianFilter(origX, origY)
filter1=zeros(5,5);
for i=1:5
    for j=1:5
        filter1(i,j)=exp((-D(i-1,j-1, origX, origY)^2)/2);
    end
end
surf(filter1);
end

function output=D(x,y, originx, originy)
output=sqrt((x-originx)^2+(y-originy)^2);
end