#include <stdio.h>
//读入n=100个整数到一个数组中
void f1(int a[], int n){
	int i, temp;
	for (int i = 0; i <= n/2-1; i++)
	{
		temp = a[i];
		a[i] = a[n - i - 1];
		a[n - i - 1] = temp;
	}
}

int main()
{
	int a[100], i;
	int n = 100;

	for (i = 0; i < n; i++)
	{
		a[i] = i;
	}
	f1(a, n);

	for (i = 0; i < n; i++)
	{
		printf("%d ", a[i]);
	}

	printf("\n");
	system("pause");
}
