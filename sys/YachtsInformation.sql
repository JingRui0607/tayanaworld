with cte as(SELECT   ROW_NUMBER() OVER(ORDER BY id asc ) 

as rowID , id, YachtsType,Overview,Layout_DeckPlan,Specifications,ListNum,MainPhoto,Downloads,NewYachts,initDate,(select Photos from YachtsAlbum where MainPhoto = 1 and  YachtsID= YachtsType.id)as Main  FROM     YachtsType )

select * from   cte  where rowID >=  (@page - 1) * @limit + 1  and rowID <= @page* @limit