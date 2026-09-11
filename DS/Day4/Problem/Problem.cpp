// Problem.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

int main()
{
    /*
    Input
The first line of input contains integer m (2 ≤ m ≤ 106).

The second line of input contains integers h1 and a1 (0 ≤ h1, a1 < m).

The third line of input contains integers x1 and y1 (0 ≤ x1, y1 < m).

The fourth line of input contains integers h2 and a2 (0 ≤ h2, a2 < m).

The fifth line of input contains integers x2 and y2 (0 ≤ x2, y2 < m).

It is guaranteed that h1 ≠ a1 and h2 ≠ a2.*/

/*
* m
* h1 , a1
, x1 , y1
  h2 , a2
  x2 , y2



*/
    int m, h1, a1, x1, y1, h2, a2, x2, y2;
    cin >> m;
    cin >> h1;
    cin >> a1;
    cin >> x1;
    cin >> y1;
    cin >> h2;
    cin >> a2;
    cin >> x2;
    cin>> y2;

    int result1, result2, seconds = 0;



    do
    {
        result1 = (h1 * x1 + y1) % m;

        result2 = (h2 * x2 + y2) % m;
        seconds++;
    } while (result1 != a1 && result2 != a2);





    cout << seconds;




    return 0;
}
