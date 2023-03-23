function output=mcdm(W, O)
[m,n] = size(O);
if(n == size(W))
    output = 'Sizeha be ham nemikhorad';
end
bad = bell(0.2,0.8,0.25);
normal = bell(0.5,0.8,0.25);
good = bell(0.8,0.8,0.25);
for i=1:m
    for j=1:n
        if(strcmp(W{j}, 'bad') && strcmp(O{i,j}, 'bad'))
            tmp{i,j} = max(1-bad, bad);
        end
        if(strcmp(W{j}, 'bad') && strcmp(O{i,j}, 'normal'))
            tmp{i,j} = max(1-bad, normal);
        end
        if(strcmp(W{j}, 'bad') && strcmp(O{i,j}, 'good'))
            tmp{i,j} = max(1-bad, good);
        end
        if(strcmp(W{j}, 'normal') && strcmp(O{i,j}, 'bad'))
            tmp{i,j} = max(1-normal, bad);
        end
        if(strcmp(W{j}, 'normal') && strcmp(O{i,j}, 'normal'))
            tmp{i,j} = max(1-normal, normal);
        end
        if(strcmp(W{j}, 'normal') && strcmp(O{i,j}, 'good'))
            tmp{i,j} = max(1-normal, good);
        end
        if(strcmp(W{j}, 'good') && strcmp(O{i,j}, 'bad'))
            tmp{i,j} = max(1-good, bad);
        end
        if(strcmp(W{j}, 'good') && strcmp(O{i,j}, 'normal'))
            tmp{i,j} = max(1-good, normal);
        end
        if(strcmp(W{j}, 'good') && strcmp(O{i,j}, 'good'))
            tmp{i,j} = max(1-good, good);
        end
    end
    tempMin = tmp{i,1};
    for j=1:n-1
        tempMin = min(tempMin,tmp{i,j+1});
    end
    ostad{i} = tempMin;
end
x=0:0.05:1;
for i=1:m
    sum = 0;
    defuzzy = 0;
    for j=1:21
        defuzzy = defuzzy + ostad{i}(j)*x(j);
        sum = sum + ostad{i}(j);
    end
    defuzzyOstad(i) = defuzzy/ sum;
end
output = defuzzyOstad;
end

function out = bell(c,b,a)
x = 0:0.05:1;
out = 1./(1+abs((x-c)./a).^(2*b));
end