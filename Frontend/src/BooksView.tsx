import { createSignal, onMount } from 'solid-js';

type SearchBy = 'Title' | 'Author' | 'Isbn';

interface Book {
    bookId: number;
    title: string;
    firstName: string;
    lastName: string;
    totalCopies: number;
    copiesInUse: number;
    type: string;
    isbn: string;
    category: string;
}

function autofocus(element: HTMLElement) {
    element.focus();
}

const BooksView = () => {
    const [searchBy, setSearchBy] = createSignal<SearchBy>('Title');
    const [searchValue, setSearchValue] = createSignal('');

    const [books, setBooks] = createSignal<Book[]>([]);

    const fetchBooks = async (event: Event) => {
        event.preventDefault();

        try {
            const response = await fetch(`${import.meta.env.VITE_BOOKS_API_URL}/books?searchBy=${searchBy()}&searchValue=${searchValue()}`);
            
            if (response.status === 404) {
                setBooks([]);
                return;
            }

            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);   
            }

            const data = await response.json();
            setBooks(data);
        } catch (error) {
            console.error('An error occurred while fetching books:', error);
            setBooks([]);
        }
    };

    const handleSearchByChange = (event: Event) => {
        const selectElement = event.target as HTMLSelectElement;
        setSearchBy(selectElement.value as SearchBy);
    };

    const handleSearchValueChange = (event: Event) => {
        const inputElement = event.target as HTMLInputElement;
        setSearchValue(inputElement.value);
    };

    onMount(() => {
        fetchBooks(new Event('submit'));
    });

    return (
        <form style={{ width: '100%', "text-align": 'left' }} onSubmit={fetchBooks}>
            <div>
                <label for="searchBy">Search By:</label>
                <select id="searchBy" value={searchBy()} onChange={handleSearchByChange}>
                    <option value="Title">Title</option>
                    <option value="Author">Author</option>
                    <option value="Isbn">ISBN</option>
                </select>
            </div>
            <div>
                <label for="searchValue">Search Value:</label>
                <input id="searchValue" type="text" value={searchValue()} onInput={handleSearchValueChange} autofocus />
            </div>
            <button type='submit'>Search</button>
            <table style={{ width: '100%' }}>
                <thead>
                    <tr>
                        <th>BookId</th>
                        <th>Title</th>
                        <th>FirstName</th>
                        <th>LastName</th>
                        <th>TotalCopies</th>
                        <th>CopiesInUse</th>
                        <th>Type</th>
                        <th>Isbn</th>
                        <th>Category</th>
                    </tr>
                </thead>
                <tbody>
                    {books().map((book) => (
                        <tr>
                            <td>{book.bookId}</td>
                            <td>{book.title}</td>
                            <td>{book.firstName}</td>
                            <td>{book.lastName}</td>
                            <td>{book.totalCopies}</td>
                            <td>{book.copiesInUse}</td>
                            <td>{book.type}</td>
                            <td>{book.isbn}</td>
                            <td>{book.category}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </form>
    );
};

export default BooksView;
