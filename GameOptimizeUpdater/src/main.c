#include <stdio.h>
#include <windows.h>

char GOdir[MAX_PATH]; // GO is GameOptimize

void init_path() {
    char appdata[MAX_PATH];

    GetEnvironmentVariableA("APPDATA", appdata, MAX_PATH);

    snprintf(GOdir, MAX_PATH, "%s\\GameOptimize", appdata);
}

int main() {
    init_path();
    printf("%s\n" ,GOdir);
}