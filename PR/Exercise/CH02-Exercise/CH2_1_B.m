function CH2_1_B()
N=1000;

m=[1 7 15;1 7 1];
S(:,:,1)=[12 0;0 1];
S(:,:,2)=[8 3;3 2];
S(:,:,3)=[2 0;0 2];
[l,c]=size(m);

P=[.6 .3 .1];

%%
X=[];
y=[];
for j=1:c

t=mvnrnd(m(:,j),S(:,:,j),fix(P(j)*N));

X=[X ;t];
y=[y ones(1,fix(P(j)*N))*j];
end
plot_data(X,y,m);
end

function plot_data(X,y,m)
[l,N]=size(X'); % N=no. of data vectors, l=dimensionality
[l,c]=size(m); % c=no. of classes
if(l ~=2)
fprintf('NO PLOT CAN BE GENERATED\n')
return
end
pale=['r+'; 'go'; 'bd'];
figure(1)
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
