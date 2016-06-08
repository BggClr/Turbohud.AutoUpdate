packages\ILRepack.2.0.10\tools\ILRepack.exe /ndebug /allowdup:AngleSharp.ConfigurationExtensions /wildcards /targetplatform:v4 /out:"release\_tmp\Turbohud.AutoUpdate.exe" Turbohud.AutoUpdate\bin\Turbohud.AutoUpdate.exe Turbohud.AutoUpdate\bin\*.dll

pushd release
	pushd _tmp
		..\..\packages\7-Zip.CommandLine.9.20.0\tools\7za.exe -tzip a release.zip
		copy release.zip ..\release.zip
	popd
	RMDIR /S /q _tmp\
popd