function soundmix2()
samp=2000;
[sound1,gg1,hh1]=wavread('speech1.wav');%,[6*40*samp+1 8*40*samp]);
[sound2,ww2,ee2]=wavread('speech2.WAV');%,[2*40*samp+1 4*40*samp]);
[sound3,y3,n3]=wavread('speech3.WAV');%,[4*40*samp+1 6*40*samp]);
sound1=sound1(:,1);
sound2=sound2(:,1);
sound3=sound3(:,1);
sample=4000;

X=[-.2 .1 .8;1 1 1]';

%% ------- plot sounds ---------
figure(1);
[s1,t]=hist(sound1,sample);
[ymax1,xmax1]=max(s1);
s1=s1./ymax1;
%s1=s1./ymax1(1);
r=['sound1 ---> Max is in position ' mat2str(xmax1) ];
subplot(2,2,1);plot(s1);title(r);
% --------------------
s2=hist(sound2,sample);
[ymax2,xmax2]=max(s2);
s2=s2./ymax2;
%s2=s2./ymax2(1);
r=['sound2 ---> Max is in position ' mat2str(xmax2) ];
subplot(2,2,2);plot(s2,'green');title(r);
% --------------------
s3=hist(sound3,sample);
[ymax3,xmax3]=max(s3);
s3=s3./ymax3;
%s3=s3./ymax3(1);
r=['sound3 ---> Max is in position ' mat2str(xmax3) ];
subplot(2,2,3);plot(s3,'red');title(r);

%-----------------------
sound=[sound1 sound2 sound3];
x=sound*X;

%% ----- step 1 -----------


q1=hist(x(:,1),sample);
[ymax1,xmax1]=max(q1);
q1=q1./std(q1)
%q1=q1./ymax1;
r=['X1 :' mat2str(X(:,1)) ' \ Max is in position ' mat2str(xmax1) ];
pause(.6);
figure(2);
subplot(1,2,1); plot(q1);
title(r);
grid on;

q2=hist(x(:,2),sample);
[ymax1,xmax1]=max(q2);
%q2=q2./ymax1;
q2=q2./std(q2);
r=['X2:' mat2str(X(:,2)) ' \ Max is in position ' mat2str(xmax1) ];
subplot(1,2,2);plot(q2,'r');

title(r);
grid on;

%% ------ step 2 ------

qq=hist(q1./q2,sample);
%qq=q1./q2;
%[ymax1,xmax1]=max(qq);
[k,xmax1]=max(find(qq~=inf));
%qq=qq./ymax1;
r=['X1 / X2 - --> Max is in position ' mat2str(xmax1) ];
pause(.6);
figure();
x=1:sample;
%plot(qq,'black');title(r);
plot(x,qq,'--rs','LineWidth',2,...
                'MarkerEdgeColor','k',...
                'MarkerFaceColor','g',...
                'MarkerSize',2);title(r);
grid on;
end


