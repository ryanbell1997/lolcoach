import { Formik } from "formik";
import userStore from '../stores/userStore';

const Registration = () => {
    interface FormVals {
        name: string,
        tag: string
    }


    const initialValues: FormVals = {
        name: '',
        tag: ''
    };


    const handleSubmit = async (values: FormVals) => {
        const response = await fetch(`http://localhost:5058/account/${values.name}/${values.tag}`, {
            method: 'GET'
        });
        const data = await response.json();
        console.log('Submitted values:', values);
        userStore.setName(values.name);
        userStore.setTag(values.tag);
        userStore.setPuuid(data.puuid);
    };


    return (
        <>
            <p className="mb-5">Register below with your name and game tag as seen on the League of Legends client.</p>

            <Formik onSubmit={handleSubmit} initialValues={initialValues}>
                {({
                    values,
                    handleChange,
                    handleBlur,
                    handleSubmit
                }) => (
                    <form onSubmit={handleSubmit} className="flex flex-col gap-2 w-1/3">
                        <label htmlFor="name">Name</label>
                        <input type="text" name="name" id="name" value={values.name} onChange={handleChange} onBlur={handleBlur} placeholder='GameName' />

                        <label htmlFor="tag">Game Tag</label>
                        <input type="text" name="tag" id="tag" value={values.tag} onChange={handleChange} onBlur={handleBlur} placeholder='EUW' />
                        <button type="submit" className="mt-4 bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600">
                            Start
                        </button>
                    </form>
                )}
            </Formik>
      </>
    );
}

export default Registration;