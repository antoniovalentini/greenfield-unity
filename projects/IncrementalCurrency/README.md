# IncrementalCurrency
Tools that will help you building the currency system of an incremental/idle game.

DoubleExtensions class provides methods to format big numbers in a shorter an prettier way.<br />

e.g.<br />
123;        // => 123<br />
1234;       // => 1.234K<br />
12345;      // => 12.345K<br />
123456;     // => 123.456K<br />
1234567;    // => 1.235M<br />
12345678;   // => 12.346M<br />
123456789;  // => 123.457M<br />
1234567890; // => 1.234B<br />
    
This repo contains a Unity project to demonstrate how to use DoubleExtensions class. See "MoneyGenerator" class.
It contains a variable money to store the total amount of money. And a variable multiplier that you can change from inspector to control how fast the total money amount will increase.

For more information visit <a href="http://www.antoniovalentini.com" target="_blank">www.antoniovalentini.com</a>.
