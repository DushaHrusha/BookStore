"use client";
import Button from "antd/es/button/button"
import { Books } from "../components/Book";
import { useEffect } from "react";

export default function BooksPage(){
    useEffect(()=>{

    }, [])
    return(
        <div>
            <Button>Добавить книгу</Button>
            
            <Books books={books}/>
        </div>
    )
}