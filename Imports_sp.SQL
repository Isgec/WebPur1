SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBHSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBHSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBHSelectByID]
  @LoginID NVarChar(8),
  @IRNo Int 
  AS
  SELECT
    [SPMT_newSBH].*  
  FROM [SPMT_newSBH] 
  WHERE
  [SPMT_newSBH].[IRNo] = @IRNo
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBHSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBHSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBHSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,IRNo Int NOT NULL
  )
  INSERT INTO #PageIndex (IRNo)
  SELECT [SPMT_newSBH].[IRNo] FROM [SPMT_newSBH]
 WHERE  
   ( 
         STR(ISNULL([SPMT_newSBH].[IRNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[PurchaseType],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[TranTypeID],'')) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBH].[IsgecGSTIN], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[BPID],'')) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBH].[SupplierGSTIN], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[SupplierName],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[SupplierGSTINNumber],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[ShipToState],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[BillNumber],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[BillRemarks],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[CreatedBy],'')) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBH].[AdviceNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[ProjectID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[ElementID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[EmployeeID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[DepartmentID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[CostCenterID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBH].[UploadBatchNo],'')) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBH].[TotalBillAmount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBH].[OrderNo], 0)) LIKE @KeyWord1
   ) 
  ORDER BY (Select @OrderBy)

    SET @RecordCount = @@RowCount

  SELECT
    [SPMT_newSBH].*  
  FROM [SPMT_newSBH] 
      INNER JOIN #PageIndex
          ON [SPMT_newSBH].[IRNo] = #PageIndex.IRNo
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBHSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBHSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBHSelectListFilteres]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  IF (@OrderBy = '')
    SET @OrderBy = 'IRNo'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,IRNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL +=  'IRNo'
  SET @LGSQL +=  ')'
  SET @LGSQL +=  ' SELECT '
  SET @LGSQL +=  '[SPMT_newSBH].[IRNo]'
  SET @LGSQL +=  ' FROM [SPMT_newSBH] '
  SET @LGSQL +=  '  WHERE 1 = 1 '
  SET @LGSQL +=  '  ORDER BY ' + @OrderBy
 
 
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [SPMT_newSBH].*  
  FROM [SPMT_newSBH] 
      INNER JOIN #PageIndex
          ON [SPMT_newSBH].[IRNo] = #PageIndex.IRNo
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBHInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBHInsert]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBHInsert]
  @PurchaseType NVarChar(50),
  @TranTypeID NVarChar(3),
  @IRReceivedOn DateTime,
  @IsgecGSTIN Int,
  @BPID NVarChar(9),
  @SupplierGSTIN Int,
  @SupplierName NVarChar(100),
  @SupplierGSTINNumber NVarChar(50),
  @ShipToState NVarChar(2),
  @BillNumber NVarChar(50),
  @BillDate DateTime,
  @BillRemarks NVarChar(500),
  @CreatedBy NVarChar(8),
  @CreatedOn DateTime,
  @AdviceNo Int,
  @ProjectID NVarChar(6),
  @ElementID NVarChar(8),
  @EmployeeID NVarChar(8),
  @DepartmentID NVarChar(6),
  @CostCenterID NVarChar(6),
  @UploadBatchNo NVarChar(50),
  @TotalBillAmount Decimal(18,2),
  @OrderNo Int,
  @Return_IRNo Int = null OUTPUT 
  AS
  INSERT [SPMT_newSBH]
  (
   [PurchaseType]
  ,[TranTypeID]
  ,[IRReceivedOn]
  ,[IsgecGSTIN]
  ,[BPID]
  ,[SupplierGSTIN]
  ,[SupplierName]
  ,[SupplierGSTINNumber]
  ,[ShipToState]
  ,[BillNumber]
  ,[BillDate]
  ,[BillRemarks]
  ,[CreatedBy]
  ,[CreatedOn]
  ,[AdviceNo]
  ,[ProjectID]
  ,[ElementID]
  ,[EmployeeID]
  ,[DepartmentID]
  ,[CostCenterID]
  ,[UploadBatchNo]
  ,[TotalBillAmount]
  ,[OrderNo]
  )
  VALUES
  (
   @PurchaseType
  ,@TranTypeID
  ,@IRReceivedOn
  ,@IsgecGSTIN
  ,@BPID
  ,@SupplierGSTIN
  ,@SupplierName
  ,@SupplierGSTINNumber
  ,@ShipToState
  ,@BillNumber
  ,@BillDate
  ,@BillRemarks
  ,@CreatedBy
  ,@CreatedOn
  ,@AdviceNo
  ,@ProjectID
  ,@ElementID
  ,@EmployeeID
  ,@DepartmentID
  ,@CostCenterID
  ,@UploadBatchNo
  ,@TotalBillAmount
  ,@OrderNo
  )
  SET @Return_IRNo = Scope_Identity()
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBHUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBHUpdate]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBHUpdate]
  @Original_IRNo Int, 
  @PurchaseType NVarChar(50),
  @TranTypeID NVarChar(3),
  @IRReceivedOn DateTime,
  @IsgecGSTIN Int,
  @BPID NVarChar(9),
  @SupplierGSTIN Int,
  @SupplierName NVarChar(100),
  @SupplierGSTINNumber NVarChar(50),
  @ShipToState NVarChar(2),
  @BillNumber NVarChar(50),
  @BillDate DateTime,
  @BillRemarks NVarChar(500),
  @CreatedBy NVarChar(8),
  @CreatedOn DateTime,
  @AdviceNo Int,
  @ProjectID NVarChar(6),
  @ElementID NVarChar(8),
  @EmployeeID NVarChar(8),
  @DepartmentID NVarChar(6),
  @CostCenterID NVarChar(6),
  @UploadBatchNo NVarChar(50),
  @TotalBillAmount Decimal(18,2),
  @OrderNo Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [SPMT_newSBH] SET 
   [PurchaseType] = @PurchaseType
  ,[TranTypeID] = @TranTypeID
  ,[IRReceivedOn] = @IRReceivedOn
  ,[IsgecGSTIN] = @IsgecGSTIN
  ,[BPID] = @BPID
  ,[SupplierGSTIN] = @SupplierGSTIN
  ,[SupplierName] = @SupplierName
  ,[SupplierGSTINNumber] = @SupplierGSTINNumber
  ,[ShipToState] = @ShipToState
  ,[BillNumber] = @BillNumber
  ,[BillDate] = @BillDate
  ,[BillRemarks] = @BillRemarks
  ,[CreatedBy] = @CreatedBy
  ,[CreatedOn] = @CreatedOn
  ,[AdviceNo] = @AdviceNo
  ,[ProjectID] = @ProjectID
  ,[ElementID] = @ElementID
  ,[EmployeeID] = @EmployeeID
  ,[DepartmentID] = @DepartmentID
  ,[CostCenterID] = @CostCenterID
  ,[UploadBatchNo] = @UploadBatchNo
  ,[TotalBillAmount] = @TotalBillAmount
  ,[OrderNo] = @OrderNo
  WHERE
  [IRNo] = @Original_IRNo
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBHDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBHDelete]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBHDelete]
  @Original_IRNo Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [SPMT_newSBH]
  WHERE
  [SPMT_newSBH].[IRNo] = @Original_IRNo
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBDSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBDSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBDSelectByID]
  @LoginID NVarChar(8),
  @IRNo Int,
  @SerialNo Int 
  AS
  SELECT
    [SPMT_newSBD].*  
  FROM [SPMT_newSBD] 
  WHERE
  [SPMT_newSBD].[IRNo] = @IRNo
  AND [SPMT_newSBD].[SerialNo] = @SerialNo
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBDSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBDSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBDSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,IRNo Int NOT NULL
 ,SerialNo Int NOT NULL
  )
  INSERT INTO #PageIndex (IRNo, SerialNo)
  SELECT [SPMT_newSBD].[IRNo], [SPMT_newSBD].[SerialNo] FROM [SPMT_newSBD]
 WHERE  
   ( 
         STR(ISNULL([SPMT_newSBD].[IRNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[SerialNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBD].[ItemDescription],'')) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[BillType], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBD].[HSNSACCode],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBD].[UOM],'')) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[Quantity], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBD].[Currency],'')) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[ConversionFactorINR], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[BasicValue], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[Discount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[ServiceCharge], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[AssessableValue], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[IGSTRate], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[IGSTAmount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[SGSTRate], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[SGSTAmount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[CGSTRate], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[CGSTAmount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[CessRate], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[CessAmount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[TotalGST], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[TotalAmount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[TotalGSTINR], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[TotalAmountINR], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBD].[ProjectID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBD].[ElementID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBD].[EmployeeID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBD].[DepartmentID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBD].[CostCenterID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([SPMT_newSBD].[UploadBatchNo],'')) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[TCSRate], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[TCSAmount], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[OrderNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([SPMT_newSBD].[POLine], 0)) LIKE @KeyWord1
   ) 
  ORDER BY (Select @OrderBy)

    SET @RecordCount = @@RowCount

  SELECT
    [SPMT_newSBD].*  
  FROM [SPMT_newSBD] 
      INNER JOIN #PageIndex
          ON [SPMT_newSBD].[IRNo] = #PageIndex.IRNo
          AND [SPMT_newSBD].[SerialNo] = #PageIndex.SerialNo
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBDSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBDSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBDSelectListFilteres]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  IF (@OrderBy = '')
    SET @OrderBy = 'IRNo, SerialNo'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,IRNo Int NOT NULL
 ,SerialNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL +=  'IRNo'
  SET @LGSQL +=  ', SerialNo'
  SET @LGSQL +=  ')'
  SET @LGSQL +=  ' SELECT '
  SET @LGSQL +=  '[SPMT_newSBD].[IRNo]'
  SET @LGSQL +=  ', [SPMT_newSBD].[SerialNo]'
  SET @LGSQL +=  ' FROM [SPMT_newSBD] '
  SET @LGSQL +=  '  WHERE 1 = 1 '
  SET @LGSQL +=  '  ORDER BY ' + @OrderBy
 
 
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [SPMT_newSBD].*  
  FROM [SPMT_newSBD] 
      INNER JOIN #PageIndex
          ON [SPMT_newSBD].[IRNo] = #PageIndex.IRNo
          AND [SPMT_newSBD].[SerialNo] = #PageIndex.SerialNo
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBDInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBDInsert]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBDInsert]
  @IRNo Int,
  @ItemDescription NVarChar(100),
  @BillType Int,
  @HSNSACCode NVarChar(20),
  @UOM NVarChar(3),
  @Quantity Decimal(18,2),
  @Currency NVarChar(50),
  @ConversionFactorINR Decimal(18,6),
  @BasicValue Decimal(18,2),
  @Discount Decimal(18,2),
  @ServiceCharge Decimal(18,2),
  @AssessableValue Decimal(18,2),
  @IGSTRate Decimal(18,2),
  @IGSTAmount Decimal(18,2),
  @SGSTRate Decimal(18,2),
  @SGSTAmount Decimal(18,2),
  @CGSTRate Decimal(18,2),
  @CGSTAmount Decimal(18,2),
  @CessRate Decimal(18,2),
  @CessAmount Decimal(18,2),
  @TotalGST Decimal(18,2),
  @TotalAmount Decimal(18,2),
  @TotalGSTINR Decimal(18,2),
  @TotalAmountINR Decimal(18,2),
  @ProjectID NVarChar(6),
  @ElementID NVarChar(8),
  @EmployeeID NVarChar(8),
  @DepartmentID NVarChar(6),
  @CostCenterID NVarChar(6),
  @UploadBatchNo NVarChar(50),
  @TCSRate Decimal(18,4),
  @TCSAmount Decimal(18,2),
  @OrderNo Int,
  @POLine Int,
  @Return_IRNo Int = null OUTPUT, 
  @Return_SerialNo Int = null OUTPUT 
  AS
  INSERT [SPMT_newSBD]
  (
   [IRNo]
  ,[ItemDescription]
  ,[BillType]
  ,[HSNSACCode]
  ,[UOM]
  ,[Quantity]
  ,[Currency]
  ,[ConversionFactorINR]
  ,[BasicValue]
  ,[Discount]
  ,[ServiceCharge]
  ,[AssessableValue]
  ,[IGSTRate]
  ,[IGSTAmount]
  ,[SGSTRate]
  ,[SGSTAmount]
  ,[CGSTRate]
  ,[CGSTAmount]
  ,[CessRate]
  ,[CessAmount]
  ,[TotalGST]
  ,[TotalAmount]
  ,[TotalGSTINR]
  ,[TotalAmountINR]
  ,[ProjectID]
  ,[ElementID]
  ,[EmployeeID]
  ,[DepartmentID]
  ,[CostCenterID]
  ,[UploadBatchNo]
  ,[TCSRate]
  ,[TCSAmount]
  ,[OrderNo]
  ,[POLine]
  )
  VALUES
  (
   @IRNo
  ,@ItemDescription
  ,@BillType
  ,@HSNSACCode
  ,@UOM
  ,@Quantity
  ,@Currency
  ,@ConversionFactorINR
  ,@BasicValue
  ,@Discount
  ,@ServiceCharge
  ,@AssessableValue
  ,@IGSTRate
  ,@IGSTAmount
  ,@SGSTRate
  ,@SGSTAmount
  ,@CGSTRate
  ,@CGSTAmount
  ,@CessRate
  ,@CessAmount
  ,@TotalGST
  ,@TotalAmount
  ,@TotalGSTINR
  ,@TotalAmountINR
  ,@ProjectID
  ,@ElementID
  ,@EmployeeID
  ,@DepartmentID
  ,@CostCenterID
  ,@UploadBatchNo
  ,@TCSRate
  ,@TCSAmount
  ,@OrderNo
  ,@POLine
  )
  SET @Return_IRNo = @IRNo
  SET @Return_SerialNo = Scope_Identity()
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBDUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBDUpdate]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBDUpdate]
  @Original_IRNo Int, 
  @Original_SerialNo Int, 
  @IRNo Int,
  @ItemDescription NVarChar(100),
  @BillType Int,
  @HSNSACCode NVarChar(20),
  @UOM NVarChar(3),
  @Quantity Decimal(18,2),
  @Currency NVarChar(50),
  @ConversionFactorINR Decimal(18,6),
  @BasicValue Decimal(18,2),
  @Discount Decimal(18,2),
  @ServiceCharge Decimal(18,2),
  @AssessableValue Decimal(18,2),
  @IGSTRate Decimal(18,2),
  @IGSTAmount Decimal(18,2),
  @SGSTRate Decimal(18,2),
  @SGSTAmount Decimal(18,2),
  @CGSTRate Decimal(18,2),
  @CGSTAmount Decimal(18,2),
  @CessRate Decimal(18,2),
  @CessAmount Decimal(18,2),
  @TotalGST Decimal(18,2),
  @TotalAmount Decimal(18,2),
  @TotalGSTINR Decimal(18,2),
  @TotalAmountINR Decimal(18,2),
  @ProjectID NVarChar(6),
  @ElementID NVarChar(8),
  @EmployeeID NVarChar(8),
  @DepartmentID NVarChar(6),
  @CostCenterID NVarChar(6),
  @UploadBatchNo NVarChar(50),
  @TCSRate Decimal(18,4),
  @TCSAmount Decimal(18,2),
  @OrderNo Int,
  @POLine Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [SPMT_newSBD] SET 
   [IRNo] = @IRNo
  ,[ItemDescription] = @ItemDescription
  ,[BillType] = @BillType
  ,[HSNSACCode] = @HSNSACCode
  ,[UOM] = @UOM
  ,[Quantity] = @Quantity
  ,[Currency] = @Currency
  ,[ConversionFactorINR] = @ConversionFactorINR
  ,[BasicValue] = @BasicValue
  ,[Discount] = @Discount
  ,[ServiceCharge] = @ServiceCharge
  ,[AssessableValue] = @AssessableValue
  ,[IGSTRate] = @IGSTRate
  ,[IGSTAmount] = @IGSTAmount
  ,[SGSTRate] = @SGSTRate
  ,[SGSTAmount] = @SGSTAmount
  ,[CGSTRate] = @CGSTRate
  ,[CGSTAmount] = @CGSTAmount
  ,[CessRate] = @CessRate
  ,[CessAmount] = @CessAmount
  ,[TotalGST] = @TotalGST
  ,[TotalAmount] = @TotalAmount
  ,[TotalGSTINR] = @TotalGSTINR
  ,[TotalAmountINR] = @TotalAmountINR
  ,[ProjectID] = @ProjectID
  ,[ElementID] = @ElementID
  ,[EmployeeID] = @EmployeeID
  ,[DepartmentID] = @DepartmentID
  ,[CostCenterID] = @CostCenterID
  ,[UploadBatchNo] = @UploadBatchNo
  ,[TCSRate] = @TCSRate
  ,[TCSAmount] = @TCSAmount
  ,[OrderNo] = @OrderNo
  ,[POLine] = @POLine
  WHERE
  [IRNo] = @Original_IRNo
  AND [SerialNo] = @Original_SerialNo
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpmtNewSBDDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSpmtNewSBDDelete]
GO
 
CREATE PROCEDURE [dbo].[spSpmtNewSBDDelete]
  @Original_IRNo Int,
  @Original_SerialNo Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [SPMT_newSBD]
  WHERE
  [SPMT_newSBD].[IRNo] = @Original_IRNo
  AND [SPMT_newSBD].[SerialNo] = @Original_SerialNo
  SET @RowCount = @@RowCount
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
