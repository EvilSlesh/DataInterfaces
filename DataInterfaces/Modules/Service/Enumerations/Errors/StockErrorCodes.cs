﻿namespace ServerService
{
    #region StockErrorCodes
    public enum StockErrorCodes
    {
        Unspecified = 0,
        /// <summary>
        /// Set when we try to modify stock level of a product that have stock disabled.
        /// </summary>
        StockDisabled = 1,
        /// <summary>
        /// Set when we try to create a stock transaction with zero amount.
        /// </summary>
        ZeroAmount = 2,
        /// <summary>
        /// Set when we have a TargetDifferentProduct flag on product stock option while not actually targeting specific product.
        /// </summary>
        TargetProductNotSet = 3,
    }
    #endregion
}