function varargout = Selection_fig(varargin)
% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @Selection_fig_OpeningFcn, ...
                   'gui_OutputFcn',  @Selection_fig_OutputFcn, ...
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


% --- Executes just before Selection_fig is made visible.
function Selection_fig_OpeningFcn(hObject, eventdata, handles, varargin)
handles.output = hObject;
guidata(hObject, handles);
function varargout = Selection_fig_OutputFcn(hObject, eventdata, handles) 
varargout{1} = handles.output;

function radiobutton1_Callback(hObject, eventdata, handles)
global nomre_1;
% select bad for nomre ostad1
global a;
a(1,1)=2;


function radiobutton2_Callback(hObject, eventdata, handles)
global nomre_1;
% select Medium for nomre ostad1
global a;
a(1,1)=3;
function radiobutton3_Callback(hObject, eventdata, handles)
global nomre_1;
% select good for nomre ostad1
global a;
a(1,1)=4;

function radiobutton44_Callback(hObject, eventdata, handles)
% select Very bad for Nomre ostad1
global a;
a(1,1)=1;

function radiobutton75_Callback(hObject, eventdata, handles)
% select very bad for Akhlaqe ostad1
global a;
a(1,2)=1;
function radiobutton74_Callback(hObject, eventdata, handles)
% select bad for Akhlaqe ostad1
global a;
a(1,2)=2;
function radiobutton45_Callback(hObject, eventdata, handles)
% select very good for nomre ostad1
global a;
a(1,1)=5;
function radiobutton72_Callback(hObject, eventdata, handles)
% select medium for Akhlaqe ostad1
global a;
a(1,2)=3;
function radiobutton73_Callback(hObject, eventdata, handles)
% select good for Akhlaqe ostad1
global a;
a(1,2)=4;
function radiobutton76_Callback(hObject, eventdata, handles)
% select very good for Akhlaqe ostad1
global a;
a(1,2)=5;
function radiobutton81_Callback(hObject, eventdata, handles)
% select very good for Akhlaqe ostad2
global a;
a(2,2)=5;
function radiobutton78_Callback(hObject, eventdata, handles)
% select  good for Akhlaqe ostad2
global a;
a(2,2)=4;
function radiobutton77_Callback(hObject, eventdata, handles)
% select Medium for Akhlaqe ostad2
global a;
a(2,2)=3;
function radiobutton79_Callback(hObject, eventdata, handles)
% select bad for Akhlaqe ostad2
global a;
a(2,2)=2;
function radiobutton80_Callback(hObject, eventdata, handles)
% select very bad for Akhlaqe ostad2
global a;
a(2,2)=1;
function radiobutton47_Callback(hObject, eventdata, handles)
% select very good for nomre ostad2
global a;
a(2,1)=5;
function radiobutton17_Callback(hObject, eventdata, handles)
% select good for nomre ostad2
global a;
a(2,1)=4;
function radiobutton16_Callback(hObject, eventdata, handles)
% select Medium for nomre ostad2
global a;
a(2,1)=3;
function radiobutton18_Callback(hObject, eventdata, handles)
% select bad for nomre ostad2
global a;
a(2,1)=2;
function radiobutton46_Callback(hObject, eventdata, handles)
% select very bad for nomre ostad2
global a;
a(2,1)=1;
function radiobutton48_Callback(hObject, eventdata, handles)
% select very bad for nomre ostad3
global a;
a(3,1)=1;
function radiobutton27_Callback(hObject, eventdata, handles)
% select  bad for nomre ostad3
global a;
a(3,1)=2;
function radiobutton25_Callback(hObject, eventdata, handles)
% select Medium for nomre ostad3
global a;
a(3,1)=3;
function radiobutton26_Callback(hObject, eventdata, handles)
% select good for nomre ostad3
global a;
a(3,1)=4;
function radiobutton49_Callback(hObject, eventdata, handles)
% select very good for nomre ostad3
global a;
a(3,1)=5;
function radiobutton156_Callback(hObject, eventdata, handles)
% select very good for nomre ostad4
global a;
a(4,1)=5;
function radiobutton153_Callback(hObject, eventdata, handles)
% select good for nomre ostad4
global a;
a(4,1)=4;
function radiobutton152_Callback(hObject, eventdata, handles)
% select Medium for nomre ostad4
global a;
a(4,1)=3;
function radiobutton154_Callback(hObject, eventdata, handles)
% select  bad for nomre ostad4
global a;
a(4,1)=2;
function radiobutton155_Callback(hObject, eventdata, handles)
% select very bad for nomre ostad4
global a;
a(4,1)=1;
function radiobutton160_Callback(hObject, eventdata, handles)
% select very bad for nomre ostad5
global a;
a(5,1)=1;
function radiobutton159_Callback(hObject, eventdata, handles)
% select  bad for nomre ostad5
global a;
a(5,1)=2;
function radiobutton157_Callback(hObject, eventdata, handles)
% select Medium for nomre ostad5
global a;
a(5,1)=3;
function radiobutton158_Callback(hObject, eventdata, handles)
% select good for nomre ostad5
global a;
a(5,1)=4;
function radiobutton161_Callback(hObject, eventdata, handles)
% select very good for nomre ostad5
global a;
a(5,1)=5;
function radiobutton85_Callback(hObject, eventdata, handles)
% select very bad for Akhlaqe ostad3
global a;
a(3,2)=1;
function radiobutton84_Callback(hObject, eventdata, handles)
% select  bad for Akhlaqe ostad3
global a;
a(3,2)=2;
function radiobutton82_Callback(hObject, eventdata, handles)
% select Medium for Akhlaqe ostad3
global a;
a(3,2)=3;
function radiobutton83_Callback(hObject, eventdata, handles)
% select good for Akhlaqe ostad3
global a;
a(3,2)=4;
function radiobutton86_Callback(hObject, eventdata, handles)
% select very good for Akhlaqe ostad3
global a;
a(3,2)=5;
function radiobutton90_Callback(hObject, eventdata, handles)
% select very bad for Akhlaqe ostad4
global a;
a(4,2)=1;
function radiobutton89_Callback(hObject, eventdata, handles)
% select bad for Akhlaqe ostad4
global a;
a(4,2)=2;
function radiobutton87_Callback(hObject, eventdata, handles)
% select Medium for Akhlaqe ostad4
global a;
a(4,2)=3;
function radiobutton88_Callback(hObject, eventdata, handles)
% select good for Akhlaqe ostad4
global a;
a(4,2)=4;
function radiobutton91_Callback(hObject, eventdata, handles)
% select very good for Akhlaqe ostad4
global a;
a(4,2)=5;
function radiobutton165_Callback(hObject, eventdata, handles)
% select very bad for Akhlaqe ostad5
global a;
a(5,2)=1;
function radiobutton164_Callback(hObject, eventdata, handles)
% select bad for Akhlaqe ostad5
global a;
a(5,2)=2;
function radiobutton162_Callback(hObject, eventdata, handles)
% select Medium for Akhlaqe ostad5
global a;
a(5,2)=3;
function radiobutton163_Callback(hObject, eventdata, handles)
% select good for Akhlaqe ostad5
global a;
a(5,2)=4;
function radiobutton166_Callback(hObject, eventdata, handles)
% select very good for Akhlaqe ostad5
global a;
a(5,2)=5;
function radiobutton115_Callback(hObject, eventdata, handles)
% select very bad for Zamine-Kari ostad1
global a;
a(1,3)=1;
function radiobutton114_Callback(hObject, eventdata, handles)
% select  bad for Zamine-Kari ostad1
global a;
a(1,3)=2;
function radiobutton112_Callback(hObject, eventdata, handles)
% select medium for Zamine-Kari ostad1
global a;
a(1,3)=3;
function radiobutton113_Callback(hObject, eventdata, handles)
% select good for Zamine-Kari ostad1
global a;
function radiobutton116_Callback(hObject, eventdata, handles)
% select very good for Zamine-Kari ostad1
global a;
a(1,3)=5;
function radiobutton120_Callback(hObject, eventdata, handles)
% select very bad for Zamine-Kari ostad2
global a;
a(2,3)=1;
function radiobutton119_Callback(hObject, eventdata, handles)
% select bad for Zamine-Kari ostad2
global a;
a(2,3)=2;
function radiobutton117_Callback(hObject, eventdata, handles)
% select medium for Zamine-Kari ostad2
global a;
a(2,3)=3;
function radiobutton118_Callback(hObject, eventdata, handles)
% select good for Zamine-Kari ostad2
global a;
a(2,3)=4;
function radiobutton121_Callback(hObject, eventdata, handles)
% select very good for Zamine-Kari ostad2
global a;
a(2,3)=5;
function radiobutton125_Callback(hObject, eventdata, handles)
% select very bad for Zamine-Karia( ,3) ostad3
global a;
a(3,3)=1;
function radiobutton124_Callback(hObject, eventdata, handles)
% select bad for Zamine-Karia( ,3) ostad3
global a;
a(3,3)=2;
function radiobutton122_Callback(hObject, eventdata, handles)
% select medium  for Zamine-Karia( ,3) ostad3
global a;
a(3,3)=3;
function radiobutton123_Callback(hObject, eventdata, handles)
% select good for Zamine-Karia( ,3) ostad3
global a;
a(3,3)=4;
function radiobutton126_Callback(hObject, eventdata, handles)
% select very good for Zamine-Karia( ,3) ostad3
global a;
a(3,3)=5;
function radiobutton130_Callback(hObject, eventdata, handles)
% select very bad for Zamine-Karia( ,3) ostad4
global a;
a(4,3)=1;
function radiobutton129_Callback(hObject, eventdata, handles)
% select bad for Zamine-Karia( ,3) ostad4
global a;
a(4,3)=2;
function radiobutton127_Callback(hObject, eventdata, handles)
% select medium for Zamine-Karia( ,3) ostad4
global a;
a(4,3)=3;
function radiobutton128_Callback(hObject, eventdata, handles)
% select good for Zamine-Karia( ,3) ostad4
global a;
a(4,3)=4;
function radiobutton131_Callback(hObject, eventdata, handles)
% select very good for Zamine-Karia( ,3) ostad4
global a;
a(4,3)=5;
function radiobutton170_Callback(hObject, eventdata, handles)
% select very bad for Zamine-Karia( ,3) ostad5
global a;
a(5,3)=1;
function radiobutton169_Callback(hObject, eventdata, handles)
% select bad for Zamine-Karia( ,3) ostad5
global a;
function radiobutton167_Callback(hObject, eventdata, handles)
% select medium for Zamine-Karia( ,3) ostad5
global a;
function radiobutton168_Callback(hObject, eventdata, handles)
% select good for Zamine-Karia( ,3) ostad5
global a;
a(5,3)=4;
function radiobutton171_Callback(hObject, eventdata, handles)
% select very good for Zamine-Karia( ,3) ostad5
global a;
a(5,3)=5;
function radiobutton135_Callback(hObject, eventdata, handles)
% select very bad for Tajrobe:a( ,4) ostad1:a(1, )
global a;
a(1,4)=1;
function radiobutton134_Callback(hObject, eventdata, handles)
% select bad=2 for Tajrobe:a( ,4) ostad1:a(1, )
global a;
a(1,4)=2;
function radiobutton132_Callback(hObject, eventdata, handles)
% select medium=3 for Tajrobe:a( ,4) ostad1:a(1, )
global a;
a(1,4)=3;
function radiobutton133_Callback(hObject, eventdata, handles)
% select good=4 for Tajrobe:a( ,4) ostad1:a(1, )
global a;
a(1,4)=4;
function radiobutton136_Callback(hObject, eventdata, handles)
% select very good=5 for Tajrobe:a( ,4) ostad1:a(1, )
global a;
a(1,4)=5;
function radiobutton140_Callback(hObject, eventdata, handles)
% select very bad for Tajrobe:a( ,4) ostad2:a(2, )
global a;
a(2,4)=1;
function radiobutton139_Callback(hObject, eventdata, handles)
% select bad=2 for Tajrobe:a( ,4) ostad2:a(2, )
global a;
a(2,4)=2;
function radiobutton137_Callback(hObject, eventdata, handles)
% select medium=3 for Tajrobe:a( ,4) ostad2:a(2, )
global a;
a(2,4)=3;
function radiobutton138_Callback(hObject, eventdata, handles)
% select good=4 for Tajrobe:a( ,4) ostad2:a(2, )
global a;
a(2,4)=4;
function radiobutton141_Callback(hObject, eventdata, handles)
% select very good=5 for Tajrobe:a( ,4) ostad2:a(2, )
global a;
a(2,4)=5;
function radiobutton145_Callback(hObject, eventdata, handles)
% select very bad for Tajrobe:a( ,4) ostad3:a(3, )
global a;
a(3,4)=1;
function radiobutton144_Callback(hObject, eventdata, handles)
% select bad=2 for Tajrobe:a( ,4) ostad3:a(3, )
global a;
a(3,4)=2;
function radiobutton142_Callback(hObject, eventdata, handles)
% select medium=3 for Tajrobe:a( ,4) ostad3:a(3, )
global a;
a(3,4)=3;

function radiobutton143_Callback(hObject, eventdata, handles)
% select good=4 for Tajrobe:a( ,4) ostad3:a(3, )
global a;
a(3,4)=4;

function radiobutton146_Callback(hObject, eventdata, handles)
% select very good=5 for Tajrobe:a( ,4) ostad3:a(3, )
global a;
a(3,4)=5;
function radiobutton150_Callback(hObject, eventdata, handles)
 select very bad for Tajrobe:a( ,4) ostad4:a(4, )
global a;
a(4,4)=1;
function radiobutton149_Callback(hObject, eventdata, handles)
% select bad=2 for Tajrobe:a( ,4) ostad4:a(4, )
global a;
a(4,4)=2;
function radiobutton147_Callback(hObject, eventdata, handles)
% select medium=3 for Tajrobe:a( ,4) ostad4:a(4, )
global a;
a(4,4)=3;
function radiobutton148_Callback(hObject, eventdata, handles)
% select good=4 for Tajrobe:a( ,4) ostad4:a(4, )
global a;
a(4,4)=4;
function radiobutton151_Callback(hObject, eventdata, handles)
% select very good=5 for Tajrobe:a( ,4) ostad4:a(4, )
global a;
a(4,4)=5;
function radiobutton180_Callback(hObject, eventdata, handles)
% select very bad for Tajrobe:a( ,4) ostad5:a(5, )
global a;
a(5,4)=1;
function radiobutton179_Callback(hObject, eventdata, handles)
% select bad=2 for Tajrobe:a( ,4) ostad5:a(5, )
global a;
a(5,4)=2;
function radiobutton177_Callback(hObject, eventdata, handles)
% select medium=3 for Tajrobe:a( ,4) ostad5:a(5, )
global a;
a(5,4)=3;
function radiobutton178_Callback(hObject, eventdata, handles)
% select good=4 for Tajrobe:a( ,4) ostad5:a(5, )
global a;
a(5,4)=4;
function radiobutton181_Callback(hObject, eventdata, handles)
% select very good=5  for Tajrobe:a( ,4) ostad5:a(5, )
global a;
a(5,4)=5;
function pushbutton1_Callback(hObject, eventdata, handles)
%%           Entekhabe chand me'yare 
%           Olaviat-bandi  5 ostad bar asase tarjihe daneshju
%           me'yar ha : Nomre - Akhlaq - Zamine kari - Tajrobe
%           khoruji : tartibe entekhab shode ostad
%           baraye  verybad=1 ; bad=2 ; 
%                   normal=3 ; good=4 ; verygood=5 
%                   vared konid

%% main
clc
global a;
Jahani=0:0.05:1;
bad=mfBell(.3);
normal=mfBell(.6);
good=mfBell(.8);
verygood=good.^2;
verybad=bad.^2;
disp('verybad=1 ; bad=2 ; normal=3 ; good=4 ; verygood=5');
disp('criteria: (N)nomreh ; (A)akhlagh  ; (Z)zamime kari ; (T)tajrobeh');

O{1}=verygood;O{2}=normal;O{3}=normal;O{4}=good;

disp('------------------------------------------');
disp('Your Inputs Are :');
disp('       N  A  Z  T');
disp('------------------------------------------');

for i=1:5
   % for j=1:4
       disp(strcat('Ostad ',int2str(i), '|',int2str(a(i,:)))); 
    %end
end

for Ii=1:5
    for Objectoini=1:4
        mfb=mfBell(a(Ii,Objectoini));
        D{Ii,Objectoini}=max((1-O{Objectoini}),mfb);
    end
    ostad{Ii}=min(min(min(D{Ii,1},D{Ii,2}),D{Ii,3}),D{Ii,4});
end

for Defuzzy_Index=1:5
    Defuzzy_Ostad(Defuzzy_Index)=Defuzzy(ostad{Defuzzy_Index},Jahani);
end

[value,priority]=sort(Defuzzy_Ostad);
disp('-------------------------------');
disp('Your Priority is :');
disp('-------------------------------');
for i=1:5
  disp(strcat(' Ostad :  ' , int2str(priority(i))));
end
%show data in staticText : text1 
% that we fill or send data string in property 'string' of text1
set(handles.text1,'string',int2str(priority'));

function output=Defuzzy(x,U)
sum_u=sum(x(:));
x_prod_U=x.*U;
sum_x_prod_u=sum(x_prod_U(:));
output=sum_x_prod_u/sum_u;

function output=mfBell(c)
x=0:.05:1;
b=1;a=0.25;
out=1./(1+abs((x-c)/a)).^(2*b);
output=out;
function edit1_CreateFcn(hObject, eventdata, handles)
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end



function edit2_CreateFcn(hObject, eventdata, handles)
% hObject    handle to edit2 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end
