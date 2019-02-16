Insert into Reviews (Name, ShortDescription)
	SELECT Name, ShortDescription FROm CitySpeaks_old.dbo.Reviews 


SET NOCOUNT ON;  
  
DECLARE @vendor_id int, @iamgeID int,  
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
		SELECT [ImageData], [ImageMimeType] from
			CitySpeaks_old.dbo.Reviews where ID = @vendor_id

	SELECT TOP 1 @iamgeID = ID from Images ORDER BY ID DESC 
	print @iamgeID

	INSERT INTO Reviews (Name, ShortDescription, ImageId)
		(SELECT Name, ShortDescription, @iamgeID from
			CitySpeaks_old.dbo.Reviews where ID = @vendor_id)  
    FETCH NEXT FROM vendor_cursor   
    INTO @vendor_id
END   
CLOSE vendor_cursor;  
DEALLOCATE vendor_cursor;  

DECLARE @iamgeID int
SELECT TOP 1 @iamgeID = ID from Images ORDER BY ID DESC 
PRINT @iamgeID

DELETE  Images

SELECT * from 