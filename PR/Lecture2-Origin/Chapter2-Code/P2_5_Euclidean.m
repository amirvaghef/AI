function Pe=P2_5_Euclidean()
N=1000;
m=[1 10 11;1 5 1];
S(:,:,1)=[7 4;4 5];
S(:,:,2)=[5 3;3 5];
S(:,:,3)=[7 4;4 5];
P=[1/3 1/3 1/3 ];

%% (A)
X=[];
y=[];
[l,c]=size(m);
for j=1:c
% Generating the [p(j)*N)] vectors from each distribution
temp=mvnrnd(m(:,j),S(:,:,j),fix(P(j)*N));
% The total number of points may be slightly less than N
% due to the fix operator
X=[X ;temp];
y=[y ones(1,fix(P(j)*N))*j];
end

%% B
% l=dimensionality, c=no. of classes
[l,N]=size(X'); % N=no. of vectors
for i=1:N
for j=1:c
 t(j)=sqrt((X(i,:)'-m(:,j))'*(X(i,:)'-m(:,j)));

end
% Determining the maximum quantity Pi*p(x|wi)
 [num,z(i)]=min(t(:));
end
plot_data(X,z,m);
%% C
Pe=compute_error(y,z);
xx=axis;

text(xx(1)+1,xx(4)-1,...
['Error =  ' num2str(Pe,4)],...
'HorizontalAlignment','left',... 
 'BackgroundColor',[.95 1 0.2],...
 'Margin',5);
end
%%
function clas_error=compute_error(y,y_est)
[q,N]=size(y); % N= no. of vectors
c=max(y); % Determining the number of classes
clas_error=0; % Counting the misclassified vectors
for i=1:N
if(y(i) ~= y_est(i))
clas_error=clas_error+1;
end
end
% Computing the classification error
clas_error =clas_error/N;
end
%% 
function plot_data(X,y,m)
[l,N]=size(X'); % N=no. of data vectors, l=dimensionality
[l,c]=size(m); % c=no. of classes
if(l ~=2)
fprintf('NO PLOT CAN BE GENERATED\n')
return
end
pale=['r+'; 'go'; 'bd'];
figure(2)
% Plot of the data vectors
hold on

for k=1:N
plot(X(k,1),X(k,2),pale(y(k),:))
end
% Plot of the class means
for j=1:c
plot(m(1,j),m(2,j),'--ks',...
                'MarkerFaceColor','y',...
                'MarkerSize',5)
end
end
