Recently we ported our .NET application to Mono  3.2.8.

I'd like to say it wasn't hard at all. Most of the things are working like a charm on Mono.

Our application is heavily using WCF services. So we found one issue.

If one WCF service calls "second" service it will work just fine.

But if "second" service will call "third" service, it will fail with timeout exception.


This project is a "Demo" of that issue.


If you run it, you will see the following output on Mono. In the same time on .NET it works like a charm.


<pre>

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

</pre>
