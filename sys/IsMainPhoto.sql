UPDATE  YachtsAlbum
SET     
MainPhoto = (select
case when
MainPhoto = 0 then 1
when MainPhoto =1 then 0
end
from YachtsAlbum WHERE   (id = @id) )
WHERE   (id = @id)



 

UPDATE  YachtsAlbum
SET     

MainPhoto = 0



WHERE   (YachtsID = @Yid and id != @id)