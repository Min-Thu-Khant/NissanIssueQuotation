USE [Nissan_Amigo]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_LastBusinessDayOfMonth]    Script Date: 11/3/2020 2:40:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Function [dbo].[fn_LastBusinessDayOfMonth](

@dt datetime

)

RETURNS datetime

AS

BEGIN

Declare @dt2 datetime

Declare @Df int

Declare @dSat int

Declare @dSun int

Select @dt2 = DATEADD(d, -1, DATEADD(m, 1 + DATEDIFF(m, 0, @dt), 0))

-- Since we cannot use SET DATEFIRST within a stored procedure, we must improvise

-- Default is 7 (Sunday). We want the equivalent of 6 (Saturday)

Select @dSat = datepart(dw, '2000-01-01') -- Known Saturday

Select @dSun = (@dSat % 7) + 1

Select @dt2 = (

CASE WHEN Datepart(dw, @dt2) = @dSun Then DateAdd(day, -2, @dt2)

WHEN Datepart(dw, @dt2) = @dSat Then DateAdd(day, -1, @dt2)

ELSE

@dt2

END)

Return @dt2

END
GO


