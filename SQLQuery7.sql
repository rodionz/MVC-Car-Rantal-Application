insert into Cars(Picture)
select BulkColumn 
From Openrowset(Bulk 'D:\cars\chevCorv.jpg', Single_Blob) as img