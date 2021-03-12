function Test-Case {
    param(
        [Parameter(Mandatory)]
        [String] $testname, 
        [Parameter(Mandatory)]
        [String] $actual, 
        [Parameter(Mandatory)]
        [String] $expected,
        [Parameter(Mandatory)]
        [ValidateScript({ $_.Ast.ParamBlock.Parameters.Count -eq 2 })]
        [Scriptblock] $lambda)
    
    if ($lambda.Invoke($actual, $expected)) { Write-Host $testname "PASSED" -ForegroundColor Green }
    else { Write-Host $testname "FAILED" -ForegroundColor Red; Write-Host "Expected: $expected"; Write-Host "Actual: $actual" }
    #Write-Host "Expected: $expected"; Write-Host "Actual: $actual"
}

$testname = "TestGoodEmail"
$actual = .\bin\Debug\net5.0\MyBank.exe account open -u joe@doe.com
$expected = 'Result: OK'
$testscript = { param($_actual, $_expected) $_actual.Split(",")[0].Equals($_expected) } #TODO: Improve GoodEmail expected response validation with random AccountID and UserSecret
Test-Case $testname $actual $expected $testscript

$testname = "TestBadEmail1"
$actual = .\bin\Debug\net5.0\MyBank.exe account open -u joe@doe
$expected = "--user-id -u [Required] : User ID (i.e. email)"
$testscript = { param($_actual, $_expected) $_actual.Equals($_expected) }
Test-Case $testname $actual $expected $testscript

$testname = "TestBadEmail2"
$actual = .\bin\Debug\net5.0\MyBank.exe account open -u joe
$expected = "--user-id -u [Required] : User ID (i.e. email)"
$testscript = { param($_actual, $_expected) $_actual.Equals($_expected) }
Test-Case $testname $actual $expected $testscript

$testname = "TestBadEmail3"
$actual = .\bin\Debug\net5.0\MyBank.exe account open -u
$expected = "--user-id -u [Required] : User ID (i.e. email)"
$testscript = { param($_actual, $_expected) $_actual.Equals($_expected) }
Test-Case $testname $actual $expected $testscript
