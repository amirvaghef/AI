function f = adpmedian(g)
[M, N] = size(g);

f = g;
f(:) = 0;
alreadyProcessed = false(size(g));

% Begin filtering.
for k = 3:2:9
   min = ordfilt2(g, 1, ones(k, k), 'symmetric');
   max = ordfilt2(g, k * k, ones(k, k), 'symmetric');
   med = medfilt2(g, [k k], 'symmetric');
   
   processUsingLevelB = (med > min) & (max > med) & ~alreadyProcessed; 
   zB = (g > min) & (max > g);
   outputZxy  = processUsingLevelB & zB;
   outputZmed = processUsingLevelB & ~zB;
   f(outputZxy) = g(outputZxy);
   f(outputZmed) = med(outputZmed);
   
   alreadyProcessed = alreadyProcessed | processUsingLevelB;
   if all(alreadyProcessed(:))
      break;
   end
end

f(~alreadyProcessed) = zmed(~alreadyProcessed);
