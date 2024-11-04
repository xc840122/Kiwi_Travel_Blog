import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

/**
 * Fetch categories and display them
 * @param {*} param0 
 * @returns 
 */
function CategoryList({ categories, selectedCategory, onCategorySelect }) {
  const handleCategoryClick = (categoryId) => {
    onCategorySelect(categoryId);
  };

  return (
    <div className="container my-4">
      <div className="d-flex justify-content-center flex-wrap gap-2">
        {categories.map(category => (
          <button
            key={category.id}
            className={`btn btn-outline-primary ${selectedCategory === category.id ? 'active' : ''}`}
            onClick={() => handleCategoryClick(category.id)}
            style={{
              minWidth: '120px',
              fontWeight: selectedCategory === category.id ? 'bold' : 'normal',
              borderWidth: selectedCategory === category.id ? '2px' : '1px',
            }}
          >
            {category.name}
          </button>
        ))}
      </div>
    </div>
  );
}

export default CategoryList;
// import React, { useEffect, useState } from 'react';
// import api from '../utils/api';
// import 'bootstrap/dist/css/bootstrap.min.css';

// function CategoryList({ onCategorySelect }) {
//   const [categories, setCategories] = useState([]);
//   const [selectedCategory, setSelectedCategory] = useState(null);

//   useEffect(() => {
//     api.get('/user/category/all')
//       .then(response => {
//         const categoryData = response.data.data;
//         setCategories(categoryData);
//         if (categoryData.length > 0) {
//           setSelectedCategory(categoryData[0].id);
//           onCategorySelect(categoryData[0].id); // Default to the first category
//         }
//       })
//       .catch(error => console.error("Error fetching categories:", error));
//   }, [onCategorySelect]);

//   const handleCategoryClick = (categoryId) => {
//     setSelectedCategory(categoryId);
//     onCategorySelect(categoryId);
//   };

//   return (
//     <div className="container my-4">
//       <div className="d-flex justify-content-center flex-wrap gap-2">
//         {categories.map(category => (
//           <button
//             key={category.id}
//             className={`btn btn-outline-primary ${selectedCategory === category.id ? 'active' : ''}`}
//             onClick={() => handleCategoryClick(category.id)}
//             style={{
//               minWidth: '120px',
//               fontWeight: selectedCategory === category.id ? 'bold' : 'normal',
//               borderWidth: selectedCategory === category.id ? '2px' : '1px',
//             }}
//           >
//             {category.name}
//           </button>
//         ))}
//       </div>
//     </div>
//   );
// }

// export default CategoryList;

