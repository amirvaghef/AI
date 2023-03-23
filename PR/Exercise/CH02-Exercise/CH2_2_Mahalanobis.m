function output=CH2_2_Mahalanobis()
N=1000;

m=[1 12 16;1 8 1];
S(:,:,1)=4*eye(2);
S(:,:,2)=4*eye(2);
S(:,:,3)=4*eye(2);
P=[1/3 1/3 1/3 ];


X=[];
y=[];
[l,c]=size(m);
for j=1:c

temp=mvnrnd(m(:,j),S(:,:,j),fix(P(j)*N));

X=[X ;temp];
y=[y ones(1,fix(P(j)*N))*j];
end


[l,N]=size(X'); 
for i=1:N
for j=1:c
 t(i,j)=sqrt((X(i,:)'-m(:,j))'*inv(S(:,:,j))*...
    (X(i,:)'-m(:,j)));
end

 [num,z(i)]=min(t(i,:));
end
plot_data(X,z,m);

output=compute_error(y,z);
xx=axis;

text(xx(1)+1,xx(4)-1,...
['Error =  ' num2str(output)],...
'HorizontalAlignment','left',... 
 'BackgroundColor',[.9 0.5 0],...
 'Margin',5);
end

function clas_error=compute_error(y,y_est)
[q,N]=size(y); 
c=max(y); 
clas_error=0;
for i=1:N
if(y(i) ~= y_est(i))
clas_error=clas_error+1;
end
end

clas_error =clas_error/N;
end


function plot_data(X,y,m)
[l,N]=size(X'); 
[l,c]=size(m); 
if(l ~=2)
fprintf('NO PLOT CAN BE GENERATED\n')
return
end
pale=['y*'; 'mo'; 'cd'];
figure(2)

hold on

for k=1:N
plot(X(k,1),X(k,2),pale(y(k),:))
end


for j=1:c
plot(m(1,j),m(2,j),'--ks',...
                'MarkerFaceColor','y',...
                'MarkerSize',5)
end

end
