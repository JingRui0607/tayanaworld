INSERT INTO YachtsType
              (YachtsType, Overview, Dimensions, Specifications,  NewYachts)
VALUES  (@YachtsType, @Overview, @Dimensions,@Specifications,@NewYachts) 
SELECT SCOPE_IDENTITY()

--SELECT SCOPE_IDENTITY()回傳影響資料表的第一個欄位的資料