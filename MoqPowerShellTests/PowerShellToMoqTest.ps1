$results = New-object -TypeName System.Collections.ArrayList
$results.Add([pscustomObject]@{TestName="CheckVMLogAnalytics";Status="Pass"})
$results.Add([pscustomObject]@{TestName="CheckVMSolutionTargeting";Status="Fail"})
$results.Add([pscustomObject]@{TestName="MichelesCode";Status="Pass"})
$results | ConvertTo-json | out-file "$((get-location).Path)\results.json"
"completed!"