using System.Xml.Linq;

namespace DefaultDocumentation.Api
{
    /// <summary>
    /// Exposes a method to handle a specific kind of <see cref="XElement"/> when writing documentation.
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Gets the name of the <see cref="XElement"/> this type handle.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Writes to a <see cref="IWriter"/> the provided <see cref="XElement"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to write to.</param>
        /// <param name="element">The <see cref="XElement"/> to write.</param>
        void Write(IWriter writer, XElement element);
    }
}
