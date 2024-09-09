"use client";
import Button from "antd/es/button/button"
import { Books } from "../components/Book";
import { useEffect, useState } from "react";
import { getAllBooks } from "../services/books";
import Title from "antd/es/typography/Title";


export default function BooksPage(){
    const [books, setBooks] = useState<Book[]>([]);
    const [loading, setLoading] = useState(true);
    useEffect(()=>{
        const getBooks = async () => {
            const books = await getAllBooks();
            setLoading(false);
            setBooks(books);
        };

        getBooks();
    }, [])
    return(
        <div>
            <Button>Добавить книгу</Button>
            {loading ? <Title>Loading....</Title> : <Books books={books}/>}
        </div>
    )
}