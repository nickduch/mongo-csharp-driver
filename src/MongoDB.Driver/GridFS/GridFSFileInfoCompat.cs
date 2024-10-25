﻿/* Copyright 2015-present MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver.Core.Misc;

namespace MongoDB.Driver.GridFS
{
    /// <summary>
    /// Represents information about a stored GridFS file (backed by a files collection document).
    /// </summary>
    [BsonSerializer(typeof(GridFSFileInfoSerializer))]
    public sealed class GridFSFileInfo : BsonDocumentBackedClass
    {
        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="GridFSFileInfo"/> class.
        /// </summary>
        /// <param name="backingDocument">The backing document.</param>
        public GridFSFileInfo(BsonDocument backingDocument)
            : base(backingDocument, GridFSFileInfoSerializer.Instance)
        {
        }

        /// <summary>
        /// Gets the backing document.
        /// </summary>
        /// <value>
        /// The backing document.
        /// </value>
        new public BsonDocument BackingDocument
        {
            get { return base.BackingDocument; }
        }

        /// <summary>
        /// Gets the size of a chunk.
        /// </summary>
        /// <value>
        /// The size of a chunk.
        /// </value>
        public int ChunkSizeBytes
        {
            get { return GetValue<int>("ChunkSizeBytes"); }
        }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string Filename
        {
            get { return GetValue<string>("Filename"); }
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public ObjectId Id
        {
            get { return GetValue<BsonValue>("IdAsBsonValue").AsObjectId; }
        }

        /// <summary>
        /// Gets the identifier as a BsonValue.
        /// </summary>
        /// <value>
        /// The identifier as a BsonValue.
        /// </value>
        [Obsolete("All new GridFS files should use an ObjectId as the Id.")]
        public BsonValue IdAsBsonValue
        {
            get { return GetValue<BsonValue>("IdAsBsonValue"); }
        }

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public long Length
        {
            get { return GetValue<long>("Length"); }
        }

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <value>
        /// The metadata.
        /// </value>
        public BsonDocument Metadata
        {
            get { return GetValue<BsonDocument>("Metadata", null); }
        }

        /// <summary>
        /// Gets the upload date time.
        /// </summary>
        /// <value>
        /// The upload date time.
        /// </value>
        public DateTime UploadDateTime
        {
            get { return GetValue<DateTime>("UploadDateTime"); }
        }
    }
}
