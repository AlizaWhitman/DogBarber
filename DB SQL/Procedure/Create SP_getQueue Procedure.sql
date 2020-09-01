USE [dogBarberShopDB]
GO

/****** Object:  StoredProcedure [dbo].[SP_getQueue]    Script Date: 9/1/2020 1:30:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_getQueue]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT Queue.ID, ClientID, UserName, AppointmentHour,BookingHour from Clients
INNER JOIN Queue on Queue.ClientID = Clients.ID
END
GO


