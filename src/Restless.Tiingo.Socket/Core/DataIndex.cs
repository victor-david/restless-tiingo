namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Provides static values for indices into the data array
    /// </summary>
    /// <remarks>
    /// This class helps manage all the various indices in one place.
    /// </remarks>
    internal static class DataIndex
    {
        /// <summary>
        /// Minium size of incoming data array. Used in validation
        /// </summary>
        internal static class MinimumSize
        {
            public const int CryptoQuote = 9;
            public const int CryptoTrade = 6;
            public const int ForexQuote = 8;
            public const int IEX = 16;
        }

        internal static class Common
        {
            /// <summary>
            /// All messages carry the update message type at index zero
            /// </summary>
            public const int UpdateMessageType = 0;
        }

        #region Forex
        internal static class Forex
        {
            /// <summary>
            /// Note: documentation is wrong
            /// </summary>
            internal static class Quote
            {
                #region Json array example
                // 0 => "Q"                 Type
                // 1 => "usdmxn"            Ticker
                // 2 => "2022-06-27..."     Timestamp
                // 3 => 1000000.0           Bid size
                // 4 => 19.90169            Bid price
                // 5 => 19.909185           Mid price
                // 6 => 1000000.0           Ask size
                // 7 => 19.91668            Ask price
                #endregion

                public const int AskPrice = 7;
                public const int AskSize = 6;
                public const int BidPrice = 4;
                public const int BidSize = 3;
                public const int MidPrice = 5;
                public const int Ticker = 1;
                public const int Timestamp = 2;
            }
        }
        #endregion

        #region Crypto
        internal static class Crypto
        {
            #region Json array example
            //   0 => "Q"               Type
            //   1 => "btcusd"          Ticker
            //   2 => "2022-06-26..."   Timestamp
            //   3 => "kraken"          Exchange
            //   4 => 0.06559046        Bid size
            //   5 => 21407.1           Bid price
            //   6 => 21407.15          Mid price
            //   7 => 2.81161919        Ask size
            //   8 => 21407.2           Ask price
            #endregion

            internal static class Quote
            {
                public const int AskPrice = 8;
                public const int AskSize = 7;
                public const int BidPrice = 5;
                public const int BidSize = 4;
                public const int Exchange = 3;
                public const int MidPrice = 6;
                public const int Ticker = 1;
                public const int Timestamp = 2;
            }

            #region Json array example
            // 0 => "T"                 Type
            // 1 => "btcusd"            Ticker
            // 2 => "2022-06-25..."     Timestamp
            // 3 => "binance"           Exchange
            // 4 => 0.018049164         Last size
            // 5 => 21110.12632         Last price
            #endregion

            internal static class Trade
            {
                public const int Exchange = 3;
                public const int LastPrice = 5;
                public const int LastSize = 4;
                public const int Ticker = 1;
                public const int Timestamp = 2;
            }
        }
        #endregion

        #region IEX
        internal static class IEX
        {
            internal static class All
            {
                public const int AfterHours = 12;   // all types   
                public const int AskPrice = 7;      // quote only
                public const int AskSize = 8;       // quote only
                public const int BidPrice = 5;      // quote only
                public const int BidSize = 4;       // quote only
                public const int Halted = 11;       // all types
                public const int Intermarket = 13;  // all types
                public const int LastPrice = 9;     // break, trade
                public const int LastSize = 10;     // break, trade
                public const int MidPrice = 6;      // quote only
                public const int Nanoseconds = 2;   // all types
                public const int NmsRule611 = 15;   // trade only
                public const int OddLot = 14;       // trade only
                public const int Ticker = 3;        // all types
                public const int Timestamp = 1;     // all types
            }

            internal static class Break
            {
            }

            internal static class Quote
            {
                public const int AskPrice = All.AskPrice;
                public const int AskSize = All.AskSize;
                public const int BidPrice = All.BidPrice;
                public const int BidSize = All.BidSize;
                public const int MidPrice = All.MidPrice;
                public const int Nanoseconds = All.Nanoseconds;
                public const int Ticker = All.Ticker;
                public const int Timestamp = All.Timestamp;

                

            }

            internal static class Trade
            {

            }

        }
        #endregion
    }

    internal static class All
    {
        public const int AfterHours = 12;   // all types   
        public const int AskPrice = 7;      // quote only
        public const int AskSize = 8;       // quote only
        public const int BidSize = 4;       // quote only
        public const int BidPrice = 5;      // quote only
        public const int Halted = 11;       // all types
        public const int Intermarket = 13;  // all types
        public const int LastPrice = 9;     // break, trade
        public const int LastSize = 10;     // break, trade
        public const int MidPrice = 6;      // quote only
        public const int Nanoseconds = 2;   // all types
        public const int NmsRule611 = 15;   // trade only
        public const int OddLot = 14;       // trade only
        public const int Ticker = 3;        // all types
        public const int Timestamp = 1;     // all types

    }
    /**
 

Update Message Type 0 char
Communicates what type of price update this is. 
Will always be "T" for last trade message, "Q" for top-of-book update message, and "B" for trade break messages.

        Date 1 datetime
        A string representing the datetime this quote or trade came in. This is the timestamp reported by IEX in JSON ISO Format.

        Nanoseconds 2 int64
        An integer representing the number of nanoseconds since POSIX (Epoch) time UTC.

        Ticker 3 string
        Ticker related to the asset.

        //Bid Size 4 int32
        //The number shares at the bid price. Only available for Quote updates, null otherwise.

        //Bid Price 5 float
        //The current highest bid price. Only available for Quote updates, null otherwise.

        //Mid Price 6 float
        //The mid price of the current timestamp when both "bidPrice" and "askPrice" are not-null. In mathematical terms:
        //mid = (bidPrice + askPrice)/2.0 This value is calculated by Tiingo and not provided by IEX.
        //Only available for Quote updates, null otherwise.

        Ask Price 7 float
        The current lowest ask price. Only available for Quote updates, null otherwise.

        Ask Size 8 int32
        The number of shares at the ask price. Only available for Quote updates, null otherwise.

        Last Price 9 float
        The last price the last trade was executed at. Only available for Trade and Break updates, null otherwise.

        Last Size 10 int32
        The amount of shares (volume) traded at the last price. Only available for Trade and Break updates, null otherwise.

        Halted 11 int32
        1 if the security/asset is halted, 0 if it is not halted (this comes from IEX).

        After Hours 12 int32
        1 if the data is after hours, 0 if the update was during market hours (this comes from IEX).

        Intermarket Sweep Order (ISO) 13 int32
        1 if the order is an intermarket sweep order (ISO) sweeping order, 0 if its a non-ISO order (this comes from IEX).

        Oddlot 14 int32
        1 if the trade is an odd lot, 0 if the trade is a round or mixed lot (this comes from IEX).
        Only available for Trade updates, null otherwise.

        NMS Rule 611 15 int32
        1 if the trade is not subject to NMS Rule 611 (trade through), 0 if the trade is subject to Rule NMS 611 (this comes from IEX).
        Only available for Trade updates, null otherwise.
 
*/
}