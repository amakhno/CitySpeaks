DECLARE @vendor_id int, @Image1Id int, @Image2Id int,  
    @message varchar(80), @product nvarchar(50);  
  
PRINT '-------- Vendor Products Report --------';  
  
DECLARE vendor_cursor CURSOR FOR   
SELECT Id  
FROM CitySpeaks_old.dbo.Reviews  
OPEN vendor_cursor    
FETCH NEXT FROM vendor_cursor   
INTO @vendor_id    
WHILE @@FETCH_STATUS = 0  
BEGIN  
  
    INSERT INTO Images (ImageData, ImageMimeType)		
		SELECT SmallImageData, SmallImageMimeType from
			CitySpeaks_old.dbo.News where NewsId = @vendor_id

	SELECT TOP 1 @Image1Id = ID from Images ORDER BY ID DESC 
	print @Image1Id

	INSERT INTO Images (ImageData, ImageMimeType)		
		SELECT BigImageData, BigImageMimeType from
			CitySpeaks_old.dbo.News where NewsId = @vendor_id

	SELECT TOP 1 @Image2Id = ID from Images ORDER BY ID DESC 
	print @Image2Id

	INSERT INTO News (Name, ShortDescription, Date, FullDescription, SmallImageId, BigImageId)
		(SELECT Name, ShortDescription, Date, FullDescription, @Image1Id, @Image2Id from
			CitySpeaks_old.dbo.News where NewsId = @vendor_id)  
    FETCH NEXT FROM vendor_cursor   
    INTO @vendor_id
END   
CLOSE vendor_cursor;  
DEALLOCATE vendor_cursor;  
