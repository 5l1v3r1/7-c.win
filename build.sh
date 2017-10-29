cd 7CWin && yarn run build
&& cd ..
&& dotnet restore ./7CWin.sln
&& dotnet publish ./7CWin.sln -c Release -o ./obj/publish