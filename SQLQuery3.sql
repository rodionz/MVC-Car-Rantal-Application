insert into Cars(Picture)
select BulkColumn 
From Openrowset(Bulk 'D:\ford-fusion.jpg', Single_Blob) as img