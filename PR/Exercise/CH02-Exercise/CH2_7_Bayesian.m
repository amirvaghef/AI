function output=CH2_7_Bayesian()
N=1000;
m=[1 4 8;1 4 1];
S(:,:,1)=2*eye(2);
S(:,:,2)=2*eye(2);
S(:,:,3)=2*eye(2);
P=[1/3 1/3 1/3 ];

%% (A)
X=[];
y=[];
[l,c]=size(m);
for j=1:c
% Generating the [p(j)*N)] vectors from each distribution
temp=mvnrnd(m(:,j),S(:,:,j),fix(P(j)*N));
% The total number of points may be slightly less than N
% due to the fix ooutputrator
X=[X ;temp];
y=[y ones(1,fix(P(j)*N))*j];
end

%% B
% l=dimensionality, c=no. of classes
[l,N]=size(X'); % N=no. of vectors
for i=1:N
for j=1:c
    Pxw(i,j)=comp_gauss_dens_val(m(:,j),S(:,:,j),X(i,:));
    t(i,j)=P(j)*Pxw(i,j);

end
% Determining the maximum quantity Pi*p(x|wi)
 [num,z(i)]=max(t(i,:));
end
plot_data(X,z,m);
%% C
output=compute_error(y,z);
xx=axis;

text(xx(1)+1,xx(4)-1,...
['Error =  ' num2str(output,3)],...
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
function z=comp_gauss_dens_val(m,S,x)
[l,q]=size(m); % l=dimensionality
z=(1/((2*pi)^ (l/2)*det(S)^ 0.5) )...
*exp(-0.5*(x'-m)'*inv(S)*(x'-m));
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
