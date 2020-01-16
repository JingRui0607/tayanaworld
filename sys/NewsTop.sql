UPDATE  YachtsNews
SET     

Newstop = (select
case when
Newstop  = 0 then 1
when Newstop  =1 then 0
end
from YachtsNews WHERE   (id = @id) )


WHERE   (id = @id)