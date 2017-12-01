c:
cd C:\DATASTRAGE
mkdir DELETE
FOR %%f IN ( *_No?Debug.csv *_No?Schedule.csv *_No?Schedule.csv *_FIC*確認用.csv *_供給流量演算処理確認用.csv ) DO MOVE /Y "%%f" DELETE
FOR %%f IN ( *_錫溶解補正量ΔS1?演算補正演算処理確認用.csv *_eventlog.log *コピー*.* ) DO MOVE /Y "%%f" DELETE
