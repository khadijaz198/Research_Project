
/* Author: Khadija Zafar
 * Date: 23rd July, 2023
 * Description: The Model class includes all the variables (fields)
 * of the CSV file with accessors and mutators.
 */

using System.ComponentModel.DataAnnotations;

namespace MVCProject.Model
{
    [Serializable]
    public class Record
    {
        [Key]
        public int Id { get; set; }

        /** Reference date */
        private String REF_DATE;
        /** Geography */
        private String GEO;

        /** Dissemination Geography Unique Identifier */
        private String DGUID;

        /** Typeof Vegatable */
        private String TypeOfProduct;

        /** Typeof Vegatable */
        private String TypeOfStorage;

        /** Unit of measure */
        private String UOM;

        /** unit of measure id */
        private String UOM_ID;

        /** Scalar factor */
        private String SCALAR_FACTOR;

        /** Scalar id */
        private String SCALAR_ID;

        /** Vector */
        private String VECTOR;

        /** Coordinate */
        private String COORDINATE;

        /** Value */
        private String VALUE;

        /** status */
        private String STATUS;

        /** symbol */
        private String SYMBOL;

        /** Terminate */
        private String TERMINATE;

        /** Decimals */
        private String DECIMALS;

        /** Default Constructor */
        public Record() { }

        public Record(
            int ID,
            String REF_DATE,
            String GEO,
            String DGUID,
            String TypeOfProduct,
            String TypeOfStorage,
            String UOM,
            String UOM_ID,
            String SCALAR_FACTOR,
            String SCALAR_ID,
            String VECTOR,
            String COORDINATE,
            String VALUE,
            String STATUS,
            String SYMBOL,
            String TERMINATE,
            String DECIMALS)
        {
            this.Id = ID;
            this.REF_DATE = REF_DATE;
            this.GEO = GEO;
            this.DGUID = DGUID;
            this.TypeOfProduct = TypeOfProduct;
            this.TypeOfStorage = TypeOfStorage;
            this.UOM = UOM;
            this.UOM_ID = UOM_ID;
            this.SCALAR_FACTOR = SCALAR_FACTOR;
            this.SCALAR_ID = SCALAR_ID;
            this.VECTOR = VECTOR;
            this.COORDINATE = COORDINATE;
            this.VALUE = VALUE;
            this.STATUS = STATUS;
            this.SYMBOL = SYMBOL;
            this.TERMINATE = TERMINATE;
            this.DECIMALS = DECIMALS;
        }

        /** Accessor for REF_DATE */
        public String getREF_DATE()
        {
            return REF_DATE;
        }
        /** Mutator for REF_DATE */
        public void setREF_DATE(String REF_DATE)
        {
            this.REF_DATE = REF_DATE;
        }
        /** Accessor for GEO */
        public String getGEO()
        {
            return GEO;
        }
        /** Mutator for GEO */
        public void setGEO(String GEO)
        {
            this.GEO = GEO;
        }
        /** Accessor for DGUID */
        public String getDGUID()
        {
            return DGUID;
        }
        /** Mutator for DGUID */
        public void setDGUID(String DGUID)
        {
            this.DGUID = DGUID;
        }
        /** Accessor for TypeOfProduct */
        public String getTypeOfProduct()
        {
            return TypeOfProduct;
        }
        /** Mutator for TypeOfProduct */
        public void setTypeOfProduct(String TypeOfProduct)
        {
            this.TypeOfProduct = TypeOfProduct;
        }

        /** Accessor for TypeOfStorage */
        public String getTypeOfStorage()
        {
            return TypeOfStorage;
        }
        /** Mutator for TypeOfStorage */
        public void setTypeOfStorage(String TypeOfStorage)
        {
            this.TypeOfStorage = TypeOfStorage;
        }
        /** Accessor for UOM */
        public String getUOM()
        {
            return UOM;
        }
        /** Mutator for UOM */
        public void setUOM(String UOM)
        {
            this.UOM = UOM;
        }
        /** Accessor for UOM_ID */
        public String getUOM_ID()
        {
            return UOM_ID;
        }
        /** Mutator for UOM_ID */
        public void setUOM_ID(String UOM_ID)
        {
            this.UOM_ID = UOM_ID;
        }
        /** Accessor for SCALAR_FACTOR */
        public string getSCALAR_FACTOR()
        {
            return SCALAR_FACTOR;
        }
        /** Mutator for SCALAR_FACTOR */
        public void setSCALAR_FACTOR(string SCALAR_FACTOR)
        {
            this.SCALAR_FACTOR = SCALAR_FACTOR;
        }
        /** Accessor for SCALAR_ID */
        public String getSCALAR_ID()
        {
            return SCALAR_ID;
        }
        /** Mutator for SCALAR_ID */
        public void setSCALAR_ID(String SCALAR_ID)
        {
            this.SCALAR_ID = SCALAR_ID;
        }
        /** Accessor for VECTOR */
        public String getVECTOR()
        {
            return VECTOR;
        }
        /** Mutator for VECTOR */
        public void setVECTOR(String VECTOR)
        {
            this.VECTOR = VECTOR;
        }
        /** Accessor for COORDINATE */
        public String getCOORDINATE()
        {
            return COORDINATE;
        }
        /** Mutator for COORDINATE */
        public void setCOORDINATE(String COORDINATE)
        {
            this.COORDINATE = COORDINATE;
        }
        /** Accessor for VALUE */
        public String getVALUE()
        {
            return VALUE;
        }
        /** Mutator for VALUE */
        public void setVALUE(String VALUE)
        {
            this.VALUE = VALUE;
        }
        /** Accessor for STATUS */
        public String getSTATUS()
        {
            return STATUS;
        }
        /** Mutator for STATUS */
        public void setSTATUS(String STATUS)
        {
            this.STATUS = STATUS;
        }
        /** Accessor for SYMBOL */
        public string getSYMBOL()
        {
            return SYMBOL;
        }
        /** Mutator for SYMBOL */
        public void setSYMBOL(string SYMBOL)
        {
            this.SYMBOL = SYMBOL;
        }
        /** Accessor for TERMINATE */
        public string getTERMINATE()
        {
            return TERMINATE;
        }
        /** Mutator for TERMINATE */
        public void setTERMINATE(String TERMINATE)
        {
            this.TERMINATE = TERMINATE;
        }
        /** Accessor for decimals */
        public String getDECIMALS()
        {
            return DECIMALS;
        }
        /** Mutator for decimals */
        public void setDECIMALS(String DECIMALS)
        {
            this.DECIMALS = DECIMALS;
        }


        public override string ToString()
        {
            return $"ID: {Id}\trefDate: {REF_DATE}\tgeo: {GEO}\tDGUID: {DGUID}\tType of Product: {TypeOfProduct}\tTypeOfStorage: {TypeOfStorage}\tUOM: {UOM}\tUOM_ID: {UOM_ID}\tSCALAR FACTOR: {SCALAR_FACTOR}\tSCALAR_ID: {SCALAR_ID}\tVECTOR: {VECTOR}\tCOORDINATE: {COORDINATE}\tVALUE: {VALUE}\tSTATUS: {STATUS}\tSYMBOL: {SYMBOL}\tTERMINATE: {TERMINATE}\tDECIMALS: {DECIMALS}"; // Adjust the format as per your requirements
        }
    }
}
