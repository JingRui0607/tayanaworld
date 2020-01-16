UPDATE  YachtsType
SET        YachtsType =@YachtsType, Overview =@Overview, Dimensions =@Dimensions, Specifications =@Specifications,Downloads=@Downloads
WHERE   (id = @id)