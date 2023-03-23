function varargout = Motevalli_Lecture2(varargin)
% MOTEVALLI_LECTURE2 M-file for Motevalli_Lecture2.fig
%      MOTEVALLI_LECTURE2, by itself, creates a new MOTEVALLI_LECTURE2 or raises the existing
%      singleton*.
%
%      H = MOTEVALLI_LECTURE2 returns the handle to a new MOTEVALLI_LECTURE2 or the handle to
%      the existing singleton*.
%
%      MOTEVALLI_LECTURE2('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in MOTEVALLI_LECTURE2.M with the given input arguments.
%
%      MOTEVALLI_LECTURE2('Property','Value',...) creates a new MOTEVALLI_LECTURE2 or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before Motevalli_Lecture2_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to Motevalli_Lecture2_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help Motevalli_Lecture2

% Last Modified by GUIDE v2.5 06-Jun-2011 19:35:31

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @Motevalli_Lecture2_OpeningFcn, ...
                   'gui_OutputFcn',  @Motevalli_Lecture2_OutputFcn, ...
                   'gui_LayoutFcn',  [] , ...
                   'gui_Callback',   []);
if nargin && ischar(varargin{1})
    gui_State.gui_Callback = str2func(varargin{1});
end

if nargout
    [varargout{1:nargout}] = gui_mainfcn(gui_State, varargin{:});
else
    gui_mainfcn(gui_State, varargin{:});
end
% End initialization code - DO NOT EDIT


% --- Executes just before Motevalli_Lecture2 is made visible.
function Motevalli_Lecture2_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to Motevalli_Lecture2 (see VARARGIN)

% Choose default command line output for Motevalli_Lecture2
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);

% UIWAIT makes Motevalli_Lecture2 wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = Motevalli_Lecture2_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;


% --- Executes on button press in P2_1a_Bayes.
function P2_1a_Bayes_Callback(hObject, eventdata, handles)
 
 N=1000;
cla %clear current axis
 %iduiclpw(figure1);
m=[1 7 15;1 7 1];
S(:,:,1)=[12 0;0 1];
S(:,:,2)=[8 3;3 2];
S(:,:,3)=[2 0;0 2];
[l,c]=size(m);
%% Experiment 2.1 Part a
P=[1/3 1/3 1/3 ];

%%
X=[];
y=[];
for j=1:c
% Generating the [p(j)*N)] vectors from each distribution
t=mvnrnd(m(:,j),S(:,:,j),fix(P(j)*N));
% The total number of points may be slightly less than N
% due to the fix operator
X=[X ;t];
y=[y ones(1,fix(P(j)*N))*j];
end
title('Practice 2-1a  Bayes');
plot_data(X,y,m);

%pause(1);



function plot_data(X,y,m)
[l,N]=size(X'); % N=no. of data vectors, l=dimensionality
[l,c]=size(m); % c=no. of classes
if(l ~=2)
fprintf('NO PLOT CAN BE GENERATED\n')
return
end
pale=['r+'; 'go'; 'bd'];
%figure(1)
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


% hObject    handle to P2_1a_Bayes (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)


% --- Executes on button press in P2_1b_Bayes.
function P2_1b_Bayes_Callback(hObject, eventdata, handles)
 cla
N=1000;

m=[1 7 15;1 7 1];
S(:,:,1)=[12 0;0 1];
S(:,:,2)=[8 3;3 2];
S(:,:,3)=[2 0;0 2];
[l,c]=size(m);
%% Experiment 2.1 Part b
P=[.6 .3 .1];

%%
X=[];
y=[];
for j=1:c
% Generating the [p(j)*N)] vectors from each distribution
t=mvnrnd(m(:,j),S(:,:,j),fix(P(j)*N));
% The total number of points may be slightly less than N
% due to the fix operator
X=[X ;t];
y=[y ones(1,fix(P(j)*N))*j];
end
title('Practice 2-1b  Bayes');
plot_data(X,y,m);


% --- Executes on button press in P2_2_Bayes.
function P2_2_Bayes_Callback(hObject, eventdata, handles)
cla

N=1000;
m=[1 12 16;1 8 1];
S(:,:,1)=4*eye(2);
S(:,:,2)= 4*eye(2);
S(:,:,3)=4*eye(2);
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
 t(j)=P(j)*comp_gauss_dens_val(m(:,j),...
S(:,:,j),X(i,:));
end
% Determining the maximum quantity Pi*p(x|wi)
 [num,z(i)]=max(t(:));
end
plot_data(X,z,m);
%% C
Pe=compute_error(y,z);
xx=axis;
title('Practice 2-2  Bayes');
text(xx(1)+2,xx(4)-3,...
['Error =  ' num2str(Pe,4)],...
'HorizontalAlignment','left',... 
 'BackgroundColor',[.95 1 0.2],...
 'Margin',5);

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

%%
function z=comp_gauss_dens_val(m,S,x)
[l,q]=size(m); % l=dimensionality
z=(1/((2*pi)^ (l/2)*det(S)^ 0.5) )...
*exp(-0.5*(x'-m)'*inv(S)*(x'-m));


% --- Executes on button press in P2_2_Euclidean.
function P2_2_Euclidean_Callback(hObject, eventdata, handles)
cla
N=1000;

m=[1 12 16;1 8 1];
S(:,:,1)=4*eye(2);
S(:,:,2)=4*eye(2);
S(:,:,3)=4*eye(2);
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
title('Practice 2-2  Euclidean');
plot_data(X,z,m);

%% C
Pe=compute_error(y,z);
xx=axis;

text(xx(1)+1,xx(4)-1,...
['Error =  ' num2str(Pe,4)],...
'HorizontalAlignment','left',... 
 'BackgroundColor',[.95 1 0.2],...
 'Margin',5);
 % Main function

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

%%
function z=comp_gauss_dens_val(m,S,x)
[l,q]=size(m); % l=dimensionality
z=(1/((2*pi)^ (l/2)*det(S)^ 0.5) )...
*exp(-0.5*(x'-m)'*inv(S)*(x'-m));


% --- Executes on button press in P2_2_Mahalanobis.
function P2_2_Mahalanobis_Callback(hObject, eventdata, handles)
% function P2_2_Mahalanobis
cla
N=1000;
title('Practice 2-2  Mahalanobis');
m=[1 12 16;1 8 1];
S(:,:,1)=4*eye(2);
S(:,:,2)=4*eye(2);
S(:,:,3)=4*eye(2);
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
 t(i,j)=sqrt((X(i,:)'-m(:,j))'*inv(S(:,:,j))*...
    (X(i,:)'-m(:,j)));
end
% Determining the maximum quantity Pi*p(x|wi)
 [num,z(i)]=min(t(i,:));
end
plot_data(X,z,m);
%% C
Pe=compute_error(y,z);
xx=axis;

text(xx(1)+1,xx(4)-1,...
['Error =  ' num2str(Pe)],...
'HorizontalAlignment','left',... 
 'BackgroundColor',[.95 1 0.2],...
 'Margin',5);

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


% --- Executes on button press in P2_3_Bayes.
function P2_3_Bayes_Callback(hObject, eventdata, handles)
%function P2_3_Bayes
 cla
N=1000;
title('Practice 2-3  Bayes');
m=[1 14 16;1 7 1];
S(:,:,1)=[5 3;3 4];
S(:,:,2)=[5 3;3 4];
S(:,:,3)=[5 3;3 4];
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
 t(j)=P(j)*comp_gauss_dens_val(m(:,j),...
S(:,:,j),X(i,:));

end
% Determining the maximum quantity Pi*p(x|wi)
 [num,z(i)]=max(t(:));
end
plot_data(X,z,m);

%% C
Pe=compute_error(y,z);
xx=axis;

text(xx(1)+1,xx(4)-1,...
['Error =  ' num2str(Pe,3)],...
'HorizontalAlignment','left',... 
 'BackgroundColor',[.95 1 0.2],...
 'Margin',5);

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

%%
function z=comp_gauss_dens_val(m,S,x)
[l,q]=size(m); % l=dimensionality
z=(1/((2*pi)^ (l/2)*det(S)^ 0.5) )...
*exp(-0.5*(x'-m)'*inv(S)*(x'-m));


% --- Executes on button press in P2_3_Euclidean.
function P2_3_Euclidean_Callback(hObject, eventdata, handles)
 % P2_3_Euclidean()
 cla

N=1000;
title('Practice 2-3  Euclidean');
m=[1 14 16;1 7 1];
S(:,:,1)=[5 3;3 4];
S(:,:,2)=[5 3;3 4];
S(:,:,3)=[5 3;3 4];
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
 Pxw(i,j)=comp_gauss_dens_val(m(:,j),S(:,:,j),X(i,:));
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

%%
function z=comp_gauss_dens_val(m,S,x)
[l,q]=size(m); % l=dimensionality
z=(1/((2*pi)^ (l/2)*det(S)^ 0.5) )...
*exp(-0.5*(x'-m)'*inv(S)*(x'-m));


% --- Executes on button press in P2_3_Bayes.


% --- Executes on button press in P2_3_Mahalanobis.
function P2_3_Mahalanobis_Callback(hObject, eventdata, handles)
%function Pe=P2_3_Mahalanobis()
cla
title('Practice 2-3  Mahalanobis');
N=1000;

m=[1 14 16;1 7 1];
S(:,:,1)=[5 3;3 4];
S(:,:,2)=[5 3;3 4];
S(:,:,3)=[5 3;3 4];
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
 t(j)=sqrt((X(i,:)'-m(:,j))'*inv(S(:,:,j))*...
    (X(i,:)'-m(:,j)));

end
% Determining the maximum quantity Pi*p(x|wi)
 [num,z(i)]=min(t(:));
end
plot_data(X,z,m);

%% C
Pe=compute_error(y,z);
xx=axis;

text(xx(1)+1,xx(4)-1,...
['Error =  ' num2str(Pe,3)],...
'HorizontalAlignment','left',... 
 'BackgroundColor',[.95 1 0.2],...
 'Margin',5);

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

%%
function z=comp_gauss_dens_val(m,S,x)
[l,q]=size(m); % l=dimensionality
z=(1/((2*pi)^ (l/2)*det(S)^ 0.5) )...
*exp(-0.5*(x'-m)'*inv(S)*(x'-m));


% --- Executes on button press in P2_4_Bayes.
function P2_4_Bayes_Callback(hObject, eventdata, handles)
%function Pe=P2_4_Bayes()
cla
title('Practice 2-4  Bayes');
N=1000;
m=[1 8 13;1 6 1];
S(:,:,1)=6*eye(2);
S(:,:,2)=6*eye(2);
S(:,:,3)=6*eye(2);
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
 t(i,j)=P(j)*comp_gauss_dens_val(m(:,j),...
S(:,:,j),X(i,:));
 
end
% Determining the maximum quantity Pi*p(x|wi)
 [num,z(i)]=max(t(i,:));
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

%%
function z=comp_gauss_dens_val(m,S,x)
[l,q]=size(m); % l=dimensionality
z=(1/((2*pi)^ (l/2)*det(S)^ 0.5) )...
*exp(-0.5*(x'-m)'*inv(S)*(x'-m));


% --- Executes on button press in P2_4_Euclidean.
function P2_4_Euclidean_Callback(hObject, eventdata, handles)
%function Pe=P2_4_Euclidean()
cla
title('Practice 2-4  Euclidean');
N=1000;

m=[1 8 13;1 6 1];
S(:,:,1)=6*eye(2);
S(:,:,2)=6*eye(2);
S(:,:,3)=6*eye(2);
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
 t(i,j)=sqrt((X(i,:)'-m(:,j))'*(X(i,:)'-m(:,j)));
  
end
% Determining the maximum quantity Pi*p(x|wi)
 [num,z(i)]=min(t(i,:));

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


% --- Executes on button press in P2_4_Mahalanobis.
function P2_4_Mahalanobis_Callback(hObject, eventdata, handles)
%function Pe=P2_4_Mahalanobis()
cla
title('Practice 2-4  Mahalanobis');
N=1000;
m=[1 8 13;1 6 1];
S(:,:,1)=6*eye(2);
S(:,:,2)=6*eye(2);
S(:,:,3)=6*eye(2);
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
 t(j)=sqrt((X(i,:)'-m(:,j))'*inv(S(:,:,j))*...
    (X(i,:)'-m(:,j)));

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


% --- Executes on button press in P2_5_Bayes.
function P2_5_Bayes_Callback(hObject, eventdata, handles)
%function Pe=P2_5_Bayes()
cla
title('Practice 2-5  Bayes');
N=1000;
m=[1 10 11;1 5 1];
S(:,:,1)=[7 4;4 5];
S(:,:,2)=[7 4;4 5];
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
 t(j)=P(j)*comp_gauss_dens_val(m(:,j),...
S(:,:,j),X(i,:));

end
% Determining the maximum quantity Pi*p(x|wi)
 [num,z(i)]=max(t(:));
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

%%
function z=comp_gauss_dens_val(m,S,x)
[l,q]=size(m); % l=dimensionality
z=(1/((2*pi)^ (l/2)*det(S)^ 0.5) )...
*exp(-0.5*(x'-m)'*inv(S)*(x'-m));


% --- Executes on button press in P2_5_Euclidean.
function P2_5_Euclidean_Callback(hObject, eventdata, handles)
%function Pe=P2_5_Euclidean()
cla
title('Practice 2-5  Euclidean');
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


% --- Executes on button press in P2_5_Mahalanobis.
function P2_5_Mahalanobis_Callback(hObject, eventdata, handles)
%function Pe=P2_5_Mahalanobis()
cla
title('Practice 2-5  Mahalanobis');
N=1000;
m=[1 10 11;1 5 1];
S(:,:,1)=[7 4;4 5];
S(:,:,2)=[7 4;4 5];
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
 t(j)=sqrt((X(i,:)'-m(:,j))'*inv(S(:,:,j))*...
    (X(i,:)'-m(:,j)));

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


% --- Executes on button press in P2_7_Bayes.
function P2_7_Bayes_Callback(hObject, eventdata, handles)
%function Pe=P2_7_Bayes()
cla
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
% due to the fix operator
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
Pe=compute_error(y,z);
xx=axis;
title('Practice 2-7 Bayes');
text(xx(1)+1,xx(4)-1,...
['Error =  ' num2str(Pe,3)],...
'HorizontalAlignment','left',... 
 'BackgroundColor',[.95 1 0.2],...
 'Margin',5);

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


%function z=comp_gauss_dens_val(m,S,x)
%[l,q]=size(m); % l=dimensionality
%z=(1/((2*pi)^ (l/2)*det(S)^ 0.5) )...
%*exp(-0.5*(x'-m)'*inv(S)*(x'-m));


% --- Executes on button press in P2_7_Euclidean.
function P2_7_Euclidean_Callback(hObject, eventdata, handles)
%function Pe=P2_7_Euclidean()
cla
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
title('Practice 2-7  Euclidean');
text(xx(1)+1,xx(4)-1,...
['Error =  ' num2str(Pe,3)],...
'HorizontalAlignment','left',... 
 'BackgroundColor',[.95 1 .2],...
 'Margin',5);
