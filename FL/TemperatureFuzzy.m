function fuzzy_Ex1()
fis=readfis('Tempature.fis');
temperature=0;
desire_temperature=1;
pe=0;
e=desire_temperature-temperature;
ed=abs(e)-abs(pe);
e_compare=0.01;
ed_compare=0.01;
ed_arr(1)=0;
e_arr(1)=0;
pe=e;
arrayTemperature(1)=0;
index_arrayTemperature=0;
%while(index_arrayTemperature<100)
while(abs(e)>e_compare && abs(ed)>ed_compare)
    u=evalfis([ed e],fis);   
    temperature=temperature+u;
    e=desire_temperature-temperature;
    ed=abs(e)-abs(pe);
    pe=e;
    index_arrayTemperature=index_arrayTemperature+1;
    arrayTemperature(index_arrayTemperature)=temperature;
    ed_arr(index_arrayTemperature)=ed;
    e_arr(index_arrayTemperature)=e;
end
plot(1:index_arrayTemperature,arrayTemperature);
axis normal
%axis([1 index_arrayTemperature -1 2]);
%figure;
%plot(1:index_arrayTemperature,ed_arr);xlabel('ed');axis([1 100 -1 2]);
%figure;
%plot(1:index_arrayTemperature,e_arr);xlabel('e');axis([1 100 -1 2]);
end
