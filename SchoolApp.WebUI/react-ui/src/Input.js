import './App.css';

function Input() {
    return (
        <div className="App">
            <form className="Form" action="/Students">
                <label for="firstName">Student's Name</label>
                <input className="input" Type="text" id="firstName" name="firstName"/>
            </form>
        </div>
    );
}

export default Input;