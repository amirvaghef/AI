function soundmix()
[sound1,gg1,hh1]=wavread('1.WAV');
[sound2,ww2,ee2]=wavread('2.WAV');
[sound3,y3,n3]=wavread('2.WAV');

[x1,y1,n1]=size(sound1);
X=[-.5 .5 1;1 1 1]';
%for i=1:x1
%if sound1(i)<0
%sound3(i)=-sound3(i);
%end


%% 55555
[x,s1]=hist(sound1,40000);

[y,s2]=hist(sound2,40000);
[z,s3]=hist(-sound3,40000);
%% ----- plot sounds -----
%plot(s1,x);title('sound1');
%figure;plot(s2,y);title('sound2');
%figure;plot(s3,z);title('sound3');
%-----------------------
sound=[s1 s2 s3];

x=sound*X;
%% ----- step 1 -----------
[j,x1]=hist(x(:,1),4000);
[jj,x2]=hist(x(:,2),4000);


%% ------ step 2 ------
%n=1:2000;
figure;plot(x1);title('x(:,1)');
figure;plot(x2);title('x(:,2)');

%% ------ step 3 ------
[kk,R]=hist(x1./x2);
figure;plot(R);title('x1/x2');
end



