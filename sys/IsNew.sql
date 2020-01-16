UPDATE  YachtsType
SET     

NewYachts = (select
case when
NewYachts = 0 then 1
when NewYachts =1 then 0
end
from YachtsType WHERE   (id = @id) )


WHERE   (id = @id)