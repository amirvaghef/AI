function averageImage()
    img = double(imread('010.png'));
    img = img + double(imread('011.png'));
    img = img + double(imread('014.png'));
    img = img + double(imread('022.png'));
    img = img + double(imread('026.png'));
    img = img + double(imread('032.png'));
    img = img + double(imread('034.png'));
    img = img + double(imread('035.png'));
    img = img + double(imread('037.png'));
    img = img + double(imread('042.png'));
    img = img + double(imread('044.png'));
    img = img + double(imread('045.png'));
    img = img + double(imread('046.png'));
    img = img + double(imread('050.png'));
    img = img + double(imread('051.png'));
    img = img + double(imread('052.png'));
    img = img + double(imread('053.png'));
    img = img + double(imread('054.png'));
    img = img + double(imread('055.png'));
    img = img + double(imread('056.png'));
    img = img + double(imread('057.png'));
    img = img + double(imread('058.png'));
    img = img + double(imread('059.png'));
    img = img + double(imread('060.png'));
    img = img + double(imread('061.png'));
    img = img + double(imread('062.png'));
    img = img + double(imread('063.png'));
    img = img + double(imread('064.png'));
    img = img + double(imread('065.png'));
    img = img + double(imread('066.png'));
    img = img + double(imread('067.png'));
    img = img + double(imread('068.png'));
    img = img + double(imread('069.png'));
    img = img + double(imread('070.png'));
    img = img + double(imread('071.png'));
    img = img + double(imread('072.png'));
    img = img + double(imread('074.png'));
    img = img + double(imread('075.png'));
    img = img + double(imread('076.png'));
    img = img + double(imread('077.png'));
    img = img + double(imread('078.png'));
    img = img + double(imread('079.png'));
    img = img + double(imread('080.png'));
    img = img + double(imread('081.png'));
    img = img + double(imread('082.png'));
    img = img + double(imread('083.png'));
    img = img + double(imread('084.png'));
    img = img + double(imread('085.png'));
    img = img + double(imread('086.png'));
    img = img + double(imread('087.png'));
    img = img + double(imread('088.png'));
    img = img + double(imread('089.png'));
    img = img + double(imread('091.png'));
    img = img + double(imread('092.png'));
    img = img + double(imread('093.png'));
    img = img + double(imread('094.png'));
    img = img + double(imread('095.png'));
    img = img + double(imread('096.png'));
    img = img + double(imread('097.png'));
    img = img + double(imread('098.png'));
    img = img + double(imread('099.png'));
    img = img + double(imread('100.png'));
    img = img + double(imread('101.png'));
    img = img + double(imread('102.png'));
    img = img + double(imread('103.png'));
    img = img + double(imread('104.png'));
    img = img + double(imread('105.png'));
    img = img + double(imread('106.png'));
    img = img + double(imread('107.png'));
    img = img + double(imread('108.png'));
    img = img + double(imread('109.png'));
    img = img + double(imread('110.png'));
    img = img + double(imread('111.png'));
    img = img + double(imread('112.png'));
    img = img + double(imread('113.png'));
    img = img + double(imread('114.png'));
    img = img + double(imread('115.png'));
    img = img + double(imread('116.png'));
    img = img + double(imread('117.png'));
    img = img + double(imread('118.png'));
    img = img + double(imread('119.png'));
    img = img + double(imread('120.png'));
    img = img + double(imread('121.png'));
    img = img + double(imread('122.png'));
    img = img + double(imread('124.png'));
    img = img + double(imread('125.png'));
    img = img + double(imread('127.png'));
    img = img + double(imread('130.png'));
    img = img + double(imread('131.png'));
    img = img + double(imread('132.png'));
    img = img + double(imread('133.png'));
    img = img + double(imread('134.png'));
    img = img + double(imread('135.png'));
    img = img + double(imread('136.png'));
    img = img + double(imread('137.png'));
    img = img + double(imread('138.png'));
    imshow((img(:,:,1)/96),[]);
    imwrite(img(:,:,1)/96,'template.jpg','jpg');
end