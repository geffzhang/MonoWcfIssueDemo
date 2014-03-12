Host services...

 - Do concurrent call in a background thread
FirstService.CallSecondServiceInSeparateThread
FirstService.CallSecondServiceInSeparateThread - Done
SecondService.DoWork
ThirdService.DoWork
SecondService.DoWork - Done
 - Done

 - Do concurrent call right from WCF Service method
FirstService.CallSecondService
SecondService.DoWork
The operation has timed-out.