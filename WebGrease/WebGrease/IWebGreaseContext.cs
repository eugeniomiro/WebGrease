// ----------------------------------------------------------------------------------------------------
// <copyright file="IWebGreaseContext.cs" company="Microsoft Corporation">
//   Copyright Microsoft Corporation, all rights reserved.
// </copyright>
// <summary>
//   The interface for the web grease context, can be used separately to mock and/or replace the context in tests.
//   See WebGreaseContext for more info on the functionality provides by implementations.
// </summary>
// ----------------------------------------------------------------------------------------------------
namespace WebGrease
{
    using System;
    using System.Collections.Generic;

    using WebGrease.Activities;
    using WebGrease.Configuration;
    using WebGrease.Preprocessing;

    /// <summary>
    /// The interface for the web grease context, can be used separately to mock and/or replace the context in tests.
    /// See WebGreaseContext for more info on the functionality provides by implementations.
    /// </summary>
    public interface IWebGreaseContext
    {
        #region Public Properties

        /// <summary>Gets the cache manager.</summary>
        ICacheManager Cache { get; }

        /// <summary>Gets the configuration.</summary>
        WebGreaseConfiguration Configuration { get; }

        /// <summary>Gets the log.</summary>
        LogManager Log { get; }

        /// <summary>Gets the time measure object.</summary>
        ITimeMeasure Measure { get; }

        /// <summary>Gets the preprocessing.</summary>
        PreprocessingManager Preprocessing { get; }

        /// <summary>Gets the session start time.</summary>
        DateTimeOffset SessionStartTime { get; }

        #endregion

        #region Public Methods and Operators


        /// <summary>Starts a section.</summary>
        /// <param name="idParts">The id parts.</param>
        /// <param name="varByContentItem">The var by content item.</param>
        /// <param name="varBySettings">The var by settings.</param>
        /// <param name="skipable">If the section is skippable.</param>
        /// <param name="sectionAction">The section action.</param>
        /// <returns>The success</returns>
        bool Section(string[] idParts, ContentItem varByContentItem, object varBySettings, bool skipable, Func<ICacheSection, bool> sectionAction);

        /// <summary>Starts a section.</summary>
        /// <param name="idParts">The id parts.</param>
        /// <param name="sectionAction">The section action.</param>
        /// <returns>The Success</returns>
        bool Section(string[] idParts, Func<string, bool> sectionAction);

        /// <summary>Starts a section.</summary>
        /// <param name="idParts">The id parts.</param>
        /// <param name="varBySettings">The var by settings.</param>
        /// <param name="skipable">If the section is skippable.</param>
        /// <param name="sectionAction">The section action.</param>
        /// <returns>The Success</returns>
        bool Section(string[] idParts, object varBySettings, bool skipable, Func<ICacheSection, bool> sectionAction);

        /// <summary>Starts a section.</summary>
        /// <param name="idParts">The id parts.</param>
        /// <param name="varByContentItem">The var by content item.</param>
        /// <param name="skipable">If the section is skippable.</param>
        /// <param name="sectionAction">The section action.</param>
        /// <returns>The Success</returns>
        bool Section(string[] idParts, ContentItem varByContentItem, bool skipable, Func<ICacheSection, bool> sectionAction);
        
        /// <summary>The clean cache.</summary>
        void CleanCache();

        /// <summary>The clean destination.</summary>
        void CleanDestination();

        /// <summary>The clean tools temp.</summary>
        void CleanToolsTemp();

        /// <summary>Gets the available files.</summary>
        /// <param name="rootDirectory">The root directory.</param>
        /// <param name="directories">The directories.</param>
        /// <param name="extensions">The extensions.</param>
        /// <param name="fileType">The file type.</param>
        /// <returns>The available files</returns>
        IDictionary<string, string> GetAvailableFiles(string rootDirectory, IList<string> directories, IList<string> extensions, FileTypes fileType);

        /// <summary>The get content hash.</summary>
        /// <param name="value">The content.</param>
        /// <returns>The <see cref="string"/>.</returns>
        string GetValueHash(string value);

        /// <summary>The get content hash.</summary>
        /// <param name="contentItem">The content.</param>
        /// <returns>The <see cref="string"/>.</returns>
        string GetContentItemHash(ContentItem contentItem);

        /// <summary>The get file hash.</summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        string GetFileHash(string filePath);

        /// <summary>The make relative.</summary>
        /// <param name="absolutePath">The absolute path.</param>
        /// <param name="relativePath">The relative path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        string MakeRelative(string absolutePath, string relativePath = null);

        /// <summary>Make a path absolute to source directory.</summary>
        /// <param name="relativePath">The relative path.</param>
        /// <returns>The absolute path.</returns>
        string GetWorkingSourceDirectory(string relativePath);

        /// <summary>The touch.</summary>
        /// <param name="filePath">The file path.</param>
        void Touch(string filePath);

        #endregion
    }
}