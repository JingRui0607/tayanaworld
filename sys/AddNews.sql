INSERT INTO YachtsNews
              (Newstop, mainphoto, title, main, brief,NewsDate)
VALUES  (@Istop, @mainphoto, @title, @main, @brief,@date)
SELECT SCOPE_IDENTITY()