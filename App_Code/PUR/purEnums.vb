Imports Microsoft.VisualBasic

Public Enum enumIndentStates
  Free = 1
  Returned = 2
  UnderApproval = 3
  PendingForOrdering = 4
  PartiallyOrdered = 5
  OrderPlaced = 6
End Enum
Public Enum enumOrderStates
  Free = 1
  Returned = 2
  Cancelled = 3
  EnquiryFloated = 4
  UnderApproval = 5
  Approved = 6
  IssuedToVendor = 7
  PartiallyReceived = 8
  MaterialReceived = 9
  Superseded = 10
End Enum
Public Enum enumReceiptStates
  Free = 1
  Returned = 2
  UnderApproval = 3
  IRCreated = 4
End Enum
Public Enum enumUsedFor
  Indent = 1
  Order = 2
  Receipt = 3
End Enum