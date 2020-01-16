with cte as(SELECT   ROW_NUMBER() OVER(ORDER BY id asc ) 

as rowID , id, Newstop, mainphoto, title, main, brief, download, 

NewsDate

, initdate FROM     YachtsNews )



select * from   cte  
--where rowID >=  (@page - 1) * @limit + 1  and rowID <= @page* @limit